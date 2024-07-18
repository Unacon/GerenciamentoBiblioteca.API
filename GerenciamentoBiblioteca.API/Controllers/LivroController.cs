using Azure.Core;
using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Commands.DeletarLivro;
using GerenciamentoBiblioteca.Application.Queries.GetAllLivros;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivro;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivros;
using GerenciamentoBiblioteca.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciamentoBiblioteca.API.Controllers
{
    [Route("api/livro")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LivroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLivros()
        {
            GetAllLivrosQuery getAllLivrosQuery = new GetAllLivrosQuery();
            List<GetAllLivrosViewModel> livros = await _mediator.Send(getAllLivrosQuery);

            if (livros.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdLivro(int id)
        {
            GetByIdLivroQuery getByIdLivro = new GetByIdLivroQuery(id);            
            GetByIdLivroViewModel livro = await _mediator.Send(getByIdLivro);

            if (getByIdLivro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLivroCommand createLivroCommand)
        {
            int idLivro = await _mediator.Send(createLivroCommand);

            CreateLivroViewModel createLivroViewModel = new CreateLivroViewModel(idLivro, createLivroCommand.Titulo, createLivroCommand.EmailAddress, createLivroCommand.ISBN, createLivroCommand.AnoPublicacao);

            return CreatedAtAction(nameof(GetByIdLivro), new { id = idLivro }, createLivroViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletarLivroCommand request = new DeletarLivroCommand(id);
            await _mediator.Send(request); 

            return NoContent();
        }
    }
}
