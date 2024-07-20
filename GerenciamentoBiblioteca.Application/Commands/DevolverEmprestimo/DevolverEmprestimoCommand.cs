using GerenciamentoBiblioteca.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Commands.DevolverEmprestimo
{
    public class DevolverEmprestimoCommand : IRequest<ResultViewModel>
    {
        public DevolverEmprestimoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
