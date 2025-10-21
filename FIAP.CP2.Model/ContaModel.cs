using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.CP2.Model
{
    public class ContaModel
    {
        public string? Id { get; set; }

        public required string NomeTitular { get; set; }

        public required string CPF { get; set; }

        public required string TipoConta { get; set; }

        public double Saldo { get; set; }

        public DateTime DataAbertura { get; set; }

        public bool Ativa { get; set; }

        public string? NumeroConta { get; set; }

        public ContaModel()
        {
            Id = Guid.NewGuid().ToString();
            DataAbertura = DateTime.Now;
            Saldo = 0;
            Ativa = true;
            NumeroConta = GerarNumeroConta();
        }

        private static string GerarNumeroConta()
        {
            var random = new Random();
            return $"{random.Next(1000, 9999)}-{random.Next(0, 9)}";
        }
    }
}
