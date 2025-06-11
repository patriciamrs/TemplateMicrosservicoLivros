using System.ComponentModel.DataAnnotations;
using Exemplo;

namespace Livros.DTO
{
    public class ExcluirLivroDTO
    {
        [Required]
        public int Id { get; set; }
        public required string Nome { get; set; }

        public required string Autor { get; set; }

        public required string Descricao { get; set; }

        public required string CodigoISBN { get; set; }

    }
}