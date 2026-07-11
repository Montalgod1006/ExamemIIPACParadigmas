using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraAhorrosApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraAhorrosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Simulation> Persons { get; set; }
            
    }
}