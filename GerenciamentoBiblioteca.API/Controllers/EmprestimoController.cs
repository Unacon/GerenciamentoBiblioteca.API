using GerenciamentoBiblioteca.Application.Commands.CadastrarEmprestimo;
using GerenciamentoBiblioteca.Application.Commands.DevolverEmprestimo;
using GerenciamentoBiblioteca.Application.Queries.GetByIdEmprestimo;
using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBiblioteca.API.Controllers
{
    [Route("api/emprestimo")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmprestimoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEmprestimo([FromBody] CadastrarEmprestimoCommand request)
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

            CadastrarEmprestimoViewModel emprestimoViewModel = new CadastrarEmprestimoViewModel(result.Data, request.IdUsuario, request.IdLivro, request.DataPrevistaDaDevolucao);

            return CreatedAtAction(nameof(GetByIdEmprestimo), new { id = result.Data }, emprestimoViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdEmprestimo(int id)
        {
            GetByIdEmprestimoCommand request = new GetByIdEmprestimoCommand(id);

            ResultViewModel<Emprestimo> result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }
       

        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> DevolucaoEmprestimo(int id)
        {
            DevolverEmprestimoCommand request = new DevolverEmprestimoCommand(id);
            ResultViewModel result = await _mediator.Send(request);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
