using GerenciamentoBiblioteca.Application.Commands.CreateLivro;
using GerenciamentoBiblioteca.Application.Commands.CreateUsuario;
using GerenciamentoBiblioteca.Application.Commands.DeletarUsuario;
using GerenciamentoBiblioteca.Application.Queries.GetAllUsuario;
using GerenciamentoBiblioteca.Application.Queries.GetByIdUsuario;
using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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
            ResultViewModel<List<GetAllUsuarioViewModel>> result = await _mediator.Send(new GetAllUsuarioCommand());

            if (!result.IsSucess)
            {
                return NotFound(result.Message);
            }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            ResultViewModel result = await _mediator.Send(new DeletarUsuarioCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioCommand request)
        {
            ResultViewModel<int> result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            CreateUsuarioViewModel usuarioViewModel = new CreateUsuarioViewModel(result.Data, request.Nome,request.Email);

            return CreatedAtAction(nameof(GetByIdUsuario), new { id = result.Data }, usuarioViewModel);
        }
    }
}
