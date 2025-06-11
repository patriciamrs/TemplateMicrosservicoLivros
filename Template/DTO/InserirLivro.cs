using System.ComponentModel.DataAnnotations;

namespace InserirLivros.DTO
{
    public class InserirLivroDTO
    {
        [Required]
        public int Id { get; set; }
        public required string Nome { get; set; }

        public required string Autor { get; set; }

        public required string Descricao { get; set; }

        public required string CodigoISBN { get; set; }

    }

 
}
