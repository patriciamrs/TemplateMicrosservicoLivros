using System.ComponentModel.DataAnnotations;

namespace Livros.DTO
{
    public class LivroDTO
    {
        [Required]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Autor { get; set; }
        public required string CodigoISBN { get; set; }
        public bool Disponibilidade { get; set; }
    }

}
