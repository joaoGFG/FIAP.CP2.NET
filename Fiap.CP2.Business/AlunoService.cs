using FIAP.CP2.Model;
using FIAP.CP2.Data;

namespace Fiap.CP2.Business
{
    public class AlunoService(ApplicationDbContext context) : IAlunoService
    {
        private readonly ApplicationDbContext _context = context;

        public List<AlunoModel> ListarTodos() => [.. _context.Alunos];
    }
}