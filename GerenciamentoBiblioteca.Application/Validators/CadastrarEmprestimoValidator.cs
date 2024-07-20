using FluentValidation;
using GerenciamentoBiblioteca.Application.Commands.CadastrarEmprestimo;

namespace GerenciamentoBiblioteca.Application.Validators
{
    public class CadastrarEmprestimoValidator : AbstractValidator<CadastrarEmprestimoCommand>
    {
        public CadastrarEmprestimoValidator()
        {
            RuleFor(i => i.IdUsuario)
                .NotEmpty()
                .WithMessage("Informe o Identificador do usuário");

            RuleFor(i => i.IdLivro)
                .NotEmpty()
                .WithMessage("Informe o identificador do livro");

            RuleFor(i => i.DataPrevistaDaDevolucao)
                .NotEmpty()
                .WithMessage("Informe a data prevista para devolução");
        }
    }
}
