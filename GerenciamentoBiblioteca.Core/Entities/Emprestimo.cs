using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int idUsuario, int idLivro, DateTime dataPrevistaDaDevolucao)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataPrevistaDaDevolucao = dataPrevistaDaDevolucao;
        }

        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime DataEmprestimo { get; private set; } = DateTime.Now;
        public DateTime DataPrevistaDaDevolucao { get; private set; }
        public DateTime? DataDevolucao { get; private set; } = null;
        public void Devolucao()
        {
            DataDevolucao = DateTime.Now;
        }
    }
}
