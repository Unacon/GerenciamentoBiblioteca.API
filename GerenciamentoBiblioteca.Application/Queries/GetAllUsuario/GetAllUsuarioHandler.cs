using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Models;
using GerenciamentoBiblioteca.Core.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace GerenciamentoBiblioteca.Application.Queries.GetAllUsuario
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioCommand, ResultViewModel<List<GetAllUsuarioViewModel>>>
    {
        private readonly IUsuarioRepository _usuariorepository;

        public GetAllUsuarioHandler(IUsuarioRepository usuariorepository)
        {
            _usuariorepository = usuariorepository;
        }

        public async Task<ResultViewModel<List<GetAllUsuarioViewModel>>> Handle(GetAllUsuarioCommand request, CancellationToken cancellationToken)
        {
            List<Usuario> usuarios = await _usuariorepository.GetAllUsuarioAsync();

            if (usuarios.IsNullOrEmpty())
            {
                return ResultViewModel<List<GetAllUsuarioViewModel>>.Error("Nenhum usuário encontrado");
            }

            List<GetAllUsuarioViewModel> usuariosViewModel = usuarios.Select(u => new GetAllUsuarioViewModel(u.Id, u.Nome, u.Email,u.Ativo)).ToList();

            return ResultViewModel<List<GetAllUsuarioViewModel>>.Sucess(usuariosViewModel);
        }
    }
}
