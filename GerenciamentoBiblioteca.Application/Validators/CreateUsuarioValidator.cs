using FluentValidation;
using GerenciamentoBiblioteca.Application.Commands.CreateUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Validators
{
    public class CreateUsuarioValidator : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioValidator() {
            RuleFor(i => i.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome do usuário");

            RuleFor(i => i.Email)
                .NotEmpty().WithMessage("Informe o email do usuário")
                .EmailAddress().WithMessage("Email inválido");
        }
    }
}
