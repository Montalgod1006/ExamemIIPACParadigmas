using CalculadoraAhorrosApi.Dtos.Simulation;
using CalculadoraAhorrosApi.Entities;

namespace CalculadoraAhorrosApi.Mappers
{
    public static class SimulationMapper
    {
        public static SimulationEntity CreateDtoToEntity(SimulationCreateDto dto, decimal finalAmount, decimal totalInterest)
        {
            return new SimulationEntity
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

        public static SimulationDto EntityToDto(SimulationEntity entity)
        {
            return new SimulationDto
            {
                Id = entity.Id,
                InitialAmount = entity.InitialAmount,
                InitialTaxYearly = entity.InitialTaxYearly,
                PlazoDeAños = entity.PlazoDeAños,
                Final = entity.FinalAmount,
                TotalInterest = entity.TotalInterest,
                CreatedDate = entity.CreatedDate
            };
        }

        public static List<SimulationDto> ListEntityToDto(List<SimulationEntity> entities)
        {
            return entities.Select(EntityToDto).ToList();
        }
    }
}