using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Commands.DeletarLivro;
using GerenciamentoBiblioteca.Application.Queries.GetAllLivros;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivro;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivros;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLivroCommand createLivroCommand)
        {
            if (!ModelState.IsValid)
            {
                List<string> messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(messages);
            }

            ResultViewModel<int> result = await _mediator.Send(createLivroCommand);

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }

            CreateLivroViewModel createLivroViewModel = new CreateLivroViewModel(result.Data, createLivroCommand.Titulo, createLivroCommand.EmailAddress, createLivroCommand.ISBN, createLivroCommand.AnoPublicacao);

            return CreatedAtAction(nameof(GetByIdLivro), new { id = result.Data }, createLivroViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLivros()
        {
            ResultViewModel<List<GetAllLivrosViewModel>> result = await _mediator.Send(new GetAllLivrosQuery());

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdLivro(int id)
        {
            ResultViewModel<GetByIdLivroViewModel> result = await _mediator.Send(new GetByIdLivroQuery(id));

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletarLivroCommand request = new DeletarLivroCommand(id);
            ResultViewModel result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }

            return NoContent();
        }
    }
}
