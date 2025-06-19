using Exemplo;
using Livros.DTO;
using Template.Infra;

namespace Livros.Servicos
{
    public class LivrosDomain
    {
        private readonly DataContext _dataContext;

        public LivrosDomain()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
        }

        public void Inserir(InserirLivros.DTO.InserirLivroDTO dadosDaInsercao)
        {
            var livro = new Livro
            {
                Id = dadosDaInsercao.Id,
                Nome = dadosDaInsercao.Nome,
                Autor = dadosDaInsercao.Autor,
                Descricao = dadosDaInsercao.Descricao,
                CodigoISBN = dadosDaInsercao.CodigoISBN,
                Disponibilidade = true
            };

            if (string.IsNullOrWhiteSpace(livro.Nome) || string.IsNullOrWhiteSpace(livro.CodigoISBN))
            {
                throw new Exception("Falta informar o nome e/ou Código ISBN do livro.");
            }

            _dataContext.Livros.Add(livro);
            _dataContext.SaveChanges();
        }

        public void Alterar(int id, AlterarLivroDTO dadosAlteracao)
        {
            var livro = _dataContext.Livros.FirstOrDefault(p => p.Id == id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado");
            }

            livro.Nome = dadosAlteracao.Nome;
            livro.Autor = dadosAlteracao.Autor;
            livro.Descricao = dadosAlteracao.Descricao;
            livro.CodigoISBN = dadosAlteracao.CodigoISBN;

            _dataContext.SaveChanges();
        }

        public List<LivroDTO> Buscar(int? Id, string Nome = null, string Autor = null, string CodigoISBN = null)
        {
            var query = _dataContext.Livros.AsQueryable();

            if (Id.HasValue)
                query = query.Where(p => p.Id == Id.Value);

            if (!string.IsNullOrWhiteSpace(Nome))
                query = query.Where(p => p.Nome.ToLower().Contains(Nome.ToLower()));

            if (!string.IsNullOrWhiteSpace(Autor))
                query = query.Where(p => p.Autor.ToLower().Contains(Autor.ToLower()));

            if (!string.IsNullOrWhiteSpace(CodigoISBN))
                query = query.Where(p => p.CodigoISBN.ToLower().Contains(CodigoISBN.ToLower()));

            var livros = query.ToList();

            return livros.Select(p => new LivroDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Autor = p.Autor,
                CodigoISBN = p.CodigoISBN,
                Disponibilidade = p.Disponibilidade
            }).ToList();
        }

        public void ExcluirLivro(int id)
        {
            var livro = _dataContext.Livros.FirstOrDefault(p => p.Id == id);

            if (livro == null)
                throw new Exception("Livro não encontrado");

            livro.Disponibilidade = false;
            _dataContext.SaveChanges();
        }

        public void AtualizarDisponibilidade(int idLivro, bool novaDisponibilidade)
        {
            var livro = _dataContext.Livros.FirstOrDefault(p => p.Id == idLivro);

            if (livro == null)
                throw new Exception("Livro não encontrado");

            livro.Disponibilidade = novaDisponibilidade;
            _dataContext.SaveChanges();
        }
    }
}
