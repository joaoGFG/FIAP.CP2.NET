using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.CP2.Model
{
    public class TransacaoModel
    {
        public string? Id { get; set; }

        public required string ContaId { get; set; }

        public required string Tipo { get; set; }

        public double Valor { get; set; }

        public DateTime DataHora { get; set; }

        public string? Descricao { get; set; }

        public string? ContaDestinoId { get; set; }

        public double SaldoAnterior { get; set; }

        public double SaldoPosterior { get; set; }

        public TransacaoModel()
        {
            Id = Guid.NewGuid().ToString();
            DataHora = DateTime.Now;
        }
    }
}
