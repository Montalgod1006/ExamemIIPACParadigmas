namespace CalculadoraAhorrosApi.Dtos.Simulation
{
    public class SimulationDto
    {   
        public string Id { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal InitialTaxYearly { get; set; }
        public int PlazoDeAños { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal TotalInterest { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}