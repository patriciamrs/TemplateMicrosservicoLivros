using Microsoft.AspNetCore.Mvc;
using Livros.Servicos;
using InserirLivros.DTO;


namespace Livros.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosDomain _livrosDomain;

        public LivrosController()
        {
            _livrosDomain = new LivrosDomain();
        }

        [Route("/api/livros/inserirNovo/{id}")]
        [HttpPost]
        public IActionResult Inserir([FromBody] InserirLivroDTO dadosDaInsercao)
        {
            try
            {
                _livrosDomain.Inserir(dadosDaInsercao);

                return Ok("Livro inserido com sucesso. ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/livros/excluirLivro/{id}")]
        [HttpDelete]

        public IActionResult Excluir(int id)
        {
            try
            {
                _livrosDomain.ExcluirLivro(id);
                return Ok("Livro excluído com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/api/livros/buscarLivro/{id}")]
        [HttpGet]
        public IActionResult Buscar(int? id, string Nome, string Autor, string codigoISBN)
        {
            try
            {
                var resultado = _livrosDomain.Buscar(id, Nome, Autor, codigoISBN);
                
                if (resultado == null || !resultado.Any())
                    return NotFound("Nenhum livro encontrado!");

                return Ok(resultado);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
