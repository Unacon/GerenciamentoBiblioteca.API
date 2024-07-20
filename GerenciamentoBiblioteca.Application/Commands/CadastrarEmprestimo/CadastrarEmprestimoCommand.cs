using GerenciamentoBiblioteca.Core.Models;
using MediatR;

namespace GerenciamentoBiblioteca.Application.Commands.CadastrarEmprestimo
{
    public class CadastrarEmprestimoCommand : IRequest<ResultViewModel<int>>
    {
        public CadastrarEmprestimoCommand(int idUsuario, int idLivro, DateTime dataPrevistaDaDevolucao)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataPrevistaDaDevolucao = dataPrevistaDaDevolucao;
        }

        public int IdUsuario { get; private set; }
        public int IdLivro { get; private set; }
        public DateTime DataPrevistaDaDevolucao { get; private set; }
    }
}
