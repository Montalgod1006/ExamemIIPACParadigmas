using CalculadoraAhorrosApi.Dtos.Simulation;
using CalculadoraAhorrosApi.Entities;

namespace CalculadoraAhorrosApi.Mappers
{
    public static class SimulationMapper
    {
        public static Simulation CreateDtoToEntity(SimulationCreateDto dto, decimal finalAmount, decimal totalInterest)
        {
            return new Simulation
            {
                Id = Guid.NewGuid().ToString(),
                InitialAmount = dto.InitialAmount,
                InitialTaxYearly = dto.InitialTaxYearly,
                PlazoDeAños = dto.PlazoDeAños,
                FinalAmount = finalAmount,
                TotalInterest = totalInterest,
                CreatedDate = DateTime.Now
            };
        }
    }
}