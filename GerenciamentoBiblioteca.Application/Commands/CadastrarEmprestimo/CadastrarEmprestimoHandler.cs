using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Commands.CadastrarEmprestimo
{
    public class CadastrarEmprestimoHandler : IRequestHandler<CadastrarEmprestimoCommand, ResultViewModel<int>>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILivrosRepository _livroRepository;

        public CadastrarEmprestimoHandler(IEmprestimoRepository emprestimoRepository, IUsuarioRepository usuarioRepository, ILivrosRepository livroRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _usuarioRepository = usuarioRepository;
            _livroRepository = livroRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CadastrarEmprestimoCommand request, CancellationToken cancellationToken)
        {
            Emprestimo emprestimo = new Emprestimo(request.IdUsuario, request.IdLivro, request.DataPrevistaDaDevolucao);

            Usuario usuario = await _usuarioRepository.GetByIdUsuarioAsync(request.IdUsuario);
            Livro livro = await _livroRepository.GetByIdAsync(request.IdLivro);

            if (usuario is null)
            {
                return ResultViewModel<int>.Error("Usuário não encontrado.");
            }
            else if (!usuario.Ativo)
            {
                return ResultViewModel<int>.Error("Usuário não está ativo.");
            }

            if (livro is null)
            {
                return ResultViewModel<int>.Error("Livro não encontrado.");
            }

            if (request.DataPrevistaDaDevolucao <= DateTime.Now)
            {
                return ResultViewModel<int>.Error("Data prevista de devolução deve ser maior que o horário atual.");
            }

            await _emprestimoRepository.CadastrarEmprestimo(emprestimo);
            return ResultViewModel<int>.Sucess(emprestimo.Id);
        }
    }
}
