using GerenciamentoBiblioteca.Application.Commands.CreateUsuario;
using GerenciamentoBiblioteca.Application.Commands.InativarUsuario;
using GerenciamentoBiblioteca.Application.Commands.ReativarUsuario;
using GerenciamentoBiblioteca.Application.Queries.GetAllUsuario;
using GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBiblioteca.API.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioCommand request)
        {
            if (!ModelState.IsValid)
            {
                List<string> messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(messages);
            }

            ResultViewModel<int> result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            CreateUsuarioViewModel usuarioViewModel = new CreateUsuarioViewModel(result.Data, request.Nome, request.Email);

            return CreatedAtAction(nameof(GetByIdUsuario), new { id = result.Data }, usuarioViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            ResultViewModel<List<GetAllUsuarioViewModel>> result = await _mediator.Send(new GetAllUsuarioCommand());

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUsuario(int id)
        {
            ResultViewModel<GetByIdUsuarioViewModel> result = await _mediator.Send(new GetByIdUsuarioCommand(id));

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}/inativar")]
        public async Task<IActionResult> InativarUsuario(int id)
        {
            ResultViewModel result = await _mediator.Send(new InativarUsuarioCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("{id}/ativar")]
        public async Task<IActionResult> AtivarUsuario(int id)
        {
            ResultViewModel result = await _mediator.Send(new ReativarUsuarioCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }


    }
}
