using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}