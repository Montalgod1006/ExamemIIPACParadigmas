using CalculadoraAhorrosApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraAhorrosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<SimulationEntity> Simulations { get; set; }
            
    }
}