using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Commands.CadastrarEmprestimo
{
    public class CadastrarEmprestimoViewModel
    {
        public CadastrarEmprestimoViewModel(int id, int idUsuario, int idLivro, DateTime dataPrevistaDaDevolucao)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataPrevistaDaDevolucao = dataPrevistaDaDevolucao;
        }

        public int Id { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdLivro { get; private set; }
        public DateTime DataPrevistaDaDevolucao { get; private set; }
    }
}
