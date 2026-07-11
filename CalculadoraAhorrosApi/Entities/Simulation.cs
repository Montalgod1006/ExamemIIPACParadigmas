using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraAhorrosApi.Entities
{
    [Table("simulations")]
    public class Simulation
    {

        public string Id { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal InitialTaxYearly { get; set; }
        public int PlazoDeAños { get; set; }
        public decimal Final { get; set; }
        public decimal TotalInterest { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}