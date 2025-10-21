using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIAP.CP2.Model;

namespace Fiap.CP2.Business
{
    public interface ITransacaoService
    {
        List<TransacaoModel> ListarTodas();
    }
}
