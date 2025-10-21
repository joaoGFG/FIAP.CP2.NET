using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIAP.CP2.Model;
using FIAP.CP2.Data;

namespace Fiap.CP2.Business
{
    public class ContaService(ApplicationDbContext context) : IContaService
    {
        private readonly ApplicationDbContext _context = context;

        public List<ContaModel> ListarTodas() => [.. _context.Contas];
    }
}
