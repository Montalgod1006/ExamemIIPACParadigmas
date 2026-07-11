using CalculadoraAhorrosApi.Dtos.Common;
using CalculadoraAhorrosApi.Dtos.Simulation;

namespace CalculadoraAhorrosApi.Services.Simulation
{
    public class SimulationService : ISimulationService
    {
        public Task<ResponseDto<SimulationActionResponseDto>> CreateAsync(SimulationCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<SimulationDto>> GetOneByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<SimulationDto>> GetOneByIdAsyncMonthly(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<SimulationDto>> GetOneByIdAsyncYearly(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<PageDto<List<SimulationDto>>>> GetPageAsync(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }
    }
}