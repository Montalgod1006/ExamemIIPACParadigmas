using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraAhorrosApi.Entities
{
    [Table("simulations")]
    public class Simulation
    {
       
        [Required()]
        [Column("id")]
        public string Id { get; set; }

        [Required()]
        [Column("initial_amount")]
        public decimal InitialAmount { get; set; }
        
        [Required()]
        [Column("initial_tax_yearly")]
        public decimal InitialTaxYearly { get; set; }
        public int PlazoDeAños { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal TotalInterest { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}