using Exemplo;
using Livros.DTO;
using Template.Infra;




namespace Livros.Servicos
{
    public class LivrosDomain
    {
        private DataContext _dataContext;

        public LivrosDomain()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
        }

        public void Inserir(InserirLivros.DTO.InserirLivroDTO dadosDaInsercao)
        {
            var livro = new Livro();

            livro.Id = dadosDaInsercao.Id;
            livro.Nome = dadosDaInsercao.Nome;
            livro.Autor = dadosDaInsercao.Autor;
            livro.Descricao = dadosDaInsercao.Descricao;
            livro.CodigoISBN = dadosDaInsercao.CodigoISBN;
            livro.Disponibilidade = true;

            if ((livro.Nome == "") || (livro.CodigoISBN == ""))
            {
                throw new Exception("Falta informar o nome e/ou Código ISBN do livro. ");
            }

            _dataContext.Add(livro);
            _dataContext.SaveChanges();


        }
        public void Alterar(int id, AlterarLivroDTO dadosAlteracao)
        {
            var livro = _dataContext.Livros.FirstOrDefault(p => p.Id == id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado");
            }
        }

        public List<LivroDTO> Buscar(int? Id, string Autor = null, string Nome = null, string CodigoISBN = null)
        {
            var query = _dataContext.Livros.AsQueryable();

            if (Id != null)
            {
                query = query.Where(p => p.Id == Id);
            }

            if (!string.IsNullOrEmpty(Autor))
            {
                query = query.Where(p => p.Autor.Contains(Autor));
            }

            if (!string.IsNullOrWhiteSpace(Nome))
            {
                query = query.Where(p => p.Nome.Contains(Nome));
            }

            if (!string.IsNullOrWhiteSpace(CodigoISBN))
            {
                query = query.Where(p => p.CodigoISBN.Contains(CodigoISBN));
            }

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
        public void ExcluirLivro(int id) //ta certo???
        {
            var livro = _dataContext.Livros.FirstOrDefault(p => p.Id == id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado");
            }

            livro.Disponibilidade = false;

            _dataContext.SaveChanges();

        }
    }
}

