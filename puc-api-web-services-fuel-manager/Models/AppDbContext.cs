using Microsoft.EntityFrameworkCore;

namespace puc_api_web_services_fuel_manager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opttions) : base(opttions)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
    }
}
