using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Commands.CreateUsuario;
using GerenciamentoBiblioteca.Application.Commands.DeletarUsuario;
using GerenciamentoBiblioteca.Application.Queries.GetAllUsuario;
using GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario;
using GerenciamentoBiblioteca.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {   
            GetAllUsuarioCommand request = new GetAllUsuarioCommand();
            List<GetAllUsuarioViewModel> usuarios = await _mediator.Send(request);

            if (usuarios.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUsuario(int id)
        {
            GetByIdUsuarioCommand request = new GetByIdUsuarioCommand(id);
            GetByIdUsuarioViewModel usuario = await _mediator.Send(request);

            if(usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            DeletarUsuarioCommand request = new DeletarUsuarioCommand(id);
            await _mediator.Send(request);
           
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioCommand request)
        {
            int idUsuario = await _mediator.Send(request);

            return CreatedAtAction(nameof(GetByIdUsuario), new { id = idUsuario }, request);
        }
    }
}
