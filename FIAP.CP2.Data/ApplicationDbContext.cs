using Microsoft.EntityFrameworkCore;
using FIAP.CP2.Model;
namespace FIAP.CP2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<AlunoModel> Alunos { get; set; }
    }
}