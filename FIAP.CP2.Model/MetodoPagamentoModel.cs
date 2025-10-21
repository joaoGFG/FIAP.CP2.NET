namespace FIAP.CP2.Model
{
    public class MetodoPagamentoModel
    {
        public string? Id { get; set; }

        public required string ContaId { get; set; }

        public required string TipoMetodo { get; set; }

        public string? Descricao { get; set; }

        public MetodoPagamentoModel()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}