# Aplicativo em Microsserviços para Controle de Empréstimo de Livros

Este projeto é uma API desenvolvida para controle de empréstimo de livros, em que será possível cadastrar livros, leitores e empréstimos. O sistema será estruturado em três microsserviços distintos, cada um responsável por uma área funcional específica.

* Microsserviço 1: Livros
* Microsserviço 2: Leitores
* Microsserviço 3: Empréstimos


## Lógica de Negócio Principal
Essa arquitetura em microsserviços permite que cada parte do sistema seja desenvolvida, implantada e escalada de forma independente, facilitando a manutenção e evolução do software.

* Registro de Empréstimo: Ao registrar um empréstimo, o microsserviço de Empréstimos interage com o microsserviço de Livros para marcar o livro como "emprestado".
* Validação de Devolução: Antes de permitir um novo empréstimo, o microsserviço de Empréstimos verifica no microsserviço de Livros se o livro já foi devolvido.
* Consulta de Livros Emprestados: O microsserviço de Empréstimos fornece uma funcionalidade para listar todos os livros atualmente emprestados a um determinado leitor.




## 📚 Microsserviço de Livros

**Funcionalidade:** Gerenciar o cadastro e o status dos livros.

**Ações:**

* Cadastrar novos livros com detalhes como título, autor, descrição e código ISBN.
* Atualizar informações de livros existentes.
* Marcar um livro como emprestado.
* Verificar se um livro está disponível para empréstimo.

## 🔀 Rotas da API 


__1. POST /api/livros/inserirNovo__

Cadastra um novo livro no sistema.

__2. DELETE /api/livros/excluirLivro/{id}__

Exclui livros já cadastrados, buscando pelo id para evitar erros.

__3. GET /api/livros/buscarLivro__

Busca livros já cadastrados no sistema, a busca pode ser feita pelo id, nome do livro, autor e código ISBN.

__4. PATCH {id}/status__

Verifica se o livro buscado(id) está disponível para empréstimo.








