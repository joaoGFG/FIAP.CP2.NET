namespace FIAP.CP2.Model
{
    public class AlunoModel
    {
        public string? Id { get; set; }

        public required string Nome { get; set; }

        public required string RM { get; set; }

        public required string Curso { get; set; }

        public AlunoModel()
        {
            Id = Guid.NewGuid().ToString();
        }


    }
}
