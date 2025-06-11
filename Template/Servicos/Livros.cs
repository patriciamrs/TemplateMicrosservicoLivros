using System.ComponentModel.DataAnnotations;
using Livros.DTO;

namespace Livros.Servicos
{
    public class Livro
    {
        public int Id {  get; set; }
        public string? Nome { get; set; }
        public string? Autor { get; set; }
        public string? Descricao { get; set; }
        [MaxLength(13)]
        public string?  CodigoISBN { get; set; }
        public bool Disponibilidade { get; set; }

        internal static object Select(Func<object, LivroDTO> value)
        {
            throw new NotImplementedException();
        }
    }
}
