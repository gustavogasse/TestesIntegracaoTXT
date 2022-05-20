using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ArquivoSaida> ArquivosSaida { get; set; }
    }
}