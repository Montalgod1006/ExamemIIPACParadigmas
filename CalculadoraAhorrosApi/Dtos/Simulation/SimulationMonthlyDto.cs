namespace CalculadoraAhorrosApi.Dtos.Simulation
{
    public class SimulationMonthlyDto
    {
        public string Id { get; set; }
        public int Month { get; set; }
        public decimal MonthlyAmount { get; set; }
        public decimal MonthlyTotalInterest { get; set; }
    }
}