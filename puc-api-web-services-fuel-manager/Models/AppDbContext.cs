using Microsoft.EntityFrameworkCore;

namespace puc_api_web_services_fuel_manager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opttions) : base(opttions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VeiculosUsuariosXref>()
                .HasKey(k => new { k.VeiculoId, k.UsuarioId });

            modelBuilder.Entity<VeiculosUsuariosXref>()
                .HasOne(k => k.Veiculo).WithMany(k => k.Usuarios)
                .HasForeignKey(k => k.VeiculoId);

            modelBuilder.Entity<VeiculosUsuariosXref>()
                .HasOne(k => k.Usuario).WithMany(k => k.Veiculos)
                .HasForeignKey(k => k.UsuarioId);
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<VeiculosUsuariosXref> VeiculosUsuariosXref { get; set; }
    }
}
