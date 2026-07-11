namespace CalculadoraAhorrosApi.Dtos.Simulation
{
    public class SimulationYearlyDto
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public decimal YearlyAmount { get; set; }
        public decimal YearlyTotalInterest { get; set; }
    }
}