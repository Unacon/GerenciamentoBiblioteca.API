using Azure.Core;
using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Commands.DeletarLivro;
using GerenciamentoBiblioteca.Application.Queries.GetAllLivros;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivro;
using GerenciamentoBiblioteca.Application.Queries.GetByIdLivros;
using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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
            ResultViewModel<List<GetAllLivrosViewModel>> result = await _mediator.Send(new GetAllLivrosQuery());

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLivroCommand createLivroCommand)
        {
            ResultViewModel<int> result = await _mediator.Send(createLivroCommand);

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }
            CreateLivroViewModel createLivroViewModel = new CreateLivroViewModel(result.Data, createLivroCommand.Titulo, createLivroCommand.EmailAddress, createLivroCommand.ISBN, createLivroCommand.AnoPublicacao);

            return CreatedAtAction(nameof(GetByIdLivro), new { id = result.Data }, createLivroViewModel);
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
