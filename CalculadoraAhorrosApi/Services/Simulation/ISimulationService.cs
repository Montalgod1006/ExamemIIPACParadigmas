using CalculadoraAhorrosApi.Dtos.Common;
using CalculadoraAhorrosApi.Dtos.Simulation;

namespace CalculadoraAhorrosApi.Services.Simulation
{
    public interface ISimulationService
    {
        Task<ResponseDto<PageDto<List<SimulationDto>>>> GetPageAsync(string searchTerm = "", int page = 1, int pageSize = 10);
         Task<ResponseDto<SimulationDto>> GetOneByIdAsync(string id);
         Task<ResponseDto<SimulationDto>> GetOneByIdAsyncMonthly(string id);
         Task<ResponseDto<SimulationDto>> GetOneByIdAsyncYearly(string id);
        Task <ResponseDto<SimulationActionResponseDto>> CreateAsync(SimulationCreateDto dto);

    }
}