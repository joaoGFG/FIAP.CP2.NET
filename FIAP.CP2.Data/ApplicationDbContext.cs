using Microsoft.EntityFrameworkCore;
using FIAP.CP2.Model;

namespace FIAP.CP2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ContaModel> Contas { get; set; }
        public DbSet<TransacaoModel> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContaModel>()
                .Property(c => c.Ativa)
                .HasConversion<int>();

            modelBuilder.Entity<ContaModel>()
                .Property(c => c.DataAbertura)
                .HasColumnType("TIMESTAMP");

            modelBuilder.Entity<TransacaoModel>()
                .Property(t => t.DataHora)
                .HasColumnType("TIMESTAMP");
        }
    }
}