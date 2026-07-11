using Microsoft.AspNetCore.Mvc;
using CalculadoraAhorrosApi.Services.Simulation;
using CalculadoraAhorrosApi.Dtos.Simulation;

namespace CalculadoraAhorrosApi.Controller
{
    [ApiController]
    [Route("api/simulation")]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService _simulationService;

        public SimulationController(ISimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPage(string searchTerm = "", int page = 1, int pageSize = 10)
        {
            var response = await _simulationService.GetPageAsync(searchTerm, page, pageSize);
            return StatusCode(Response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(string id)
        {
            var result = await _simulationService.GetOneByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/monthly")]
        public async Task<ActionResult> GetOneMonthly(string id)
        {
            var result = await _simulationService.GetOneByIdAsyncMonthly(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}/yearly")]
        public async Task<ActionResult> GetOneYearly(string id)
        {
            var result = await _simulationService.GetOneByIdAsyncYearly(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SimulationCreateDto dto)
        {
            var result = await _simulationService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }
    }
}