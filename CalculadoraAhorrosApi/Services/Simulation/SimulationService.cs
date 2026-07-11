using CalculadoraAhorrosApi.Constants;
using CalculadoraAhorrosApi.Data;
using CalculadoraAhorrosApi.Dtos.Common;
using CalculadoraAhorrosApi.Dtos.Simulation;
using CalculadoraAhorrosApi.Entities;
using CalculadoraAhorrosApi.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraAhorrosApi.Services.Simulation
{
    public class SimulationService : ISimulationService
    {
        private readonly AppDbContext _context;
        private readonly int PAGE_SIZE;
        private readonly int PAGE_SIZE_LIMIT;

        public SimulationService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
            PAGE_SIZE_LIMIT = configuration.GetValue<int>("PageSizeLimit");
        }
        public async Task<ResponseDto<PageDto<List<SimulationDto>>>> GetPageAsync(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            page = Math.Abs(page);
            pageSize = Math.Abs(pageSize);
            pageSize = pageSize <= 0 ? PAGE_SIZE : pageSize;
            pageSize = pageSize > PAGE_SIZE_LIMIT ? PAGE_SIZE_LIMIT : pageSize;

            int startIndex = (page - 1)* pageSize;

            IQueryable<SimulationEntity> simulationsQuery = _context.Simulations;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                simulationsQuery = simulationsQuery.Where( x => (x.Id).Contains(searchTerm) );
            }

            int totalRows = await simulationsQuery.CountAsync(); 

            var simulationsEntity = await simulationsQuery  
                .OrderBy(x => x.CreatedDate)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();

            return new ResponseDto<PageDto<List<SimulationDto>>>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = HttpMessageResponse.REGISTERS_FOUND,
                Data = new PageDto<List<SimulationDto>>
                {
                    CurrentPage = page == 0 ? 1 : page,
                    PageSize = pageSize,
                    TotalItems = totalRows,
                    TotalPages = (int)Math.Ceiling((double)totalRows/pageSize),
                    Items = SimulationMapper.ListEntityToDto(simulationsEntity),
                    HasNextPage = startIndex +pageSize < PAGE_SIZE_LIMIT && 
                        page < (int)Math.Ceiling((double)totalRows/pageSize),
                    HasPreviousPage = page > 1
                }
            };
        }
        public async Task<ResponseDto<SimulationDto>> GetOneByIdAsync(string id)
        {
            var simulationEntity = await _context.Simulations
            .FirstOrDefaultAsync(
               p => p.Id == id
            );
            if (simulationEntity is null)
            {
                return new ResponseDto<SimulationDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND,
                    Status = false,
                };
            }
            return new ResponseDto<SimulationDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Message = HttpMessageResponse.REGISTER_FOUND,
                Status = true,
                Data = SimulationMapper.EntityToDto(simulationEntity),
            };
        }

        public async Task<ResponseDto<List<SimulationDto>>> GetOneByIdAsyncMonthly(string id)
        {
            var simulationEntity = await _context.Simulations.FirstOrDefaultAsync(x => x.Id == id);

            if(simulationEntity is null)
            {
                return new ResponseDto<List<SimulationDto>>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND
                };
            }

            List<SimulationDto> months = new List<SimulationDto>();

            decimal previousAmount = simulationEntity.InitialAmount;
            decimal monthlyRate = simulationEntity.InitialTaxYearly / 12;
            int totalMonths = simulationEntity.PlazoDeAños * 12;

            for(int month = 1; month <= totalMonths; month++)
            {
                decimal currentAmount = simulationEntity.InitialAmount * (decimal)Math.Pow((double)(1 + monthlyRate), month);
                decimal interestGenerated = currentAmount - previousAmount;
                months.Add(new SimulationDto
                {
                    Id = simulationEntity.Id,
                    InitialAmount = month,
                    FinalAmount = currentAmount,
                    TotalInterest = interestGenerated
                });

                previousAmount = currentAmount;
            }
            return new ResponseDto<List<SimulationDto>>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = HttpMessageResponse.REGISTER_FOUND,
                Data = months
            };

        }
        public async Task<ResponseDto<List<SimulationDto>>> GetOneByIdAsyncYearly(string id)
        {
            var simulationEntity = await _context.Simulations.FirstOrDefaultAsync(x => x.Id == id);

            if(simulationEntity is null)
            {
                return new ResponseDto<List<SimulationDto>>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND
                };
            }

            List<SimulationDto> years = new List<SimulationDto>();

            decimal previousAmount = simulationEntity.InitialAmount;

            decimal monthlyRate = simulationEntity.InitialTaxYearly / 12;



            for(int year = 1; year <= simulationEntity.PlazoDeAños; year++)
            {
                int month = year * 12;
                decimal currentAmount = simulationEntity.InitialAmount * (decimal)Math.Pow((double)(1 + monthlyRate), month);

                decimal interestGenerated = currentAmount - previousAmount;

                years.Add(new SimulationDto
                {
                    Id = simulationEntity.Id,
                    InitialAmount = year,
                    FinalAmount = currentAmount,
                    TotalInterest = interestGenerated
                });
                previousAmount = currentAmount;

            }

            return new ResponseDto<List<SimulationDto>>
            {
                StatusCode = HttpStatusCode.Ok,
                Status = true,
                Message = HttpMessageResponse.REGISTER_FOUND,
                Data = years
            };
        }

        public async Task<ResponseDto<SimulationActionResponseDto>> CreateAsync(SimulationCreateDto dto)
        {
            decimal finalAmount,  totalInterest;
            totalInterest = dto.InitialAmount*(dto.PlazoDeAños*12) - dto.InitialAmount;
            finalAmount = dto.InitialAmount*(dto.PlazoDeAños*12);

            if(dto.InitialAmount <= 0  ||  dto.InitialTaxYearly <= 0  ||dto.PlazoDeAños <= 0)
            {
                return new ResponseDto<SimulationActionResponseDto>
                {
                    StatusCode = HttpStatusCode.BAD_REQUEST,
                    Status = false,
                    Message = "Los valores deben ser mayores a cero"
                };
            }

            SimulationEntity simulationEntity = SimulationMapper.CreateDtoToEntity(dto, finalAmount, totalInterest);

            _context.Simulations.Add(simulationEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<SimulationActionResponseDto>
            {
                StatusCode = HttpStatusCode.Ok,
                Message = HttpMessageResponse.REGISTER_CREATED,
                Status = true,
                Data = new SimulationActionResponseDto
                {
                    Id = simulationEntity.Id
                }
            };
        }
    }
}