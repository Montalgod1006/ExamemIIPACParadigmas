using System.ComponentModel.DataAnnotations;

namespace CalculadoraAhorrosApi.Dtos.Simulation
{
    public class SimulationCreateDto
    {
        [Required]
        public decimal InitialAmount { get; set; }

        [Required]
        public decimal InitialTaxYearly { get; set; }

        [Required]
        public int PlazoDeAños { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}