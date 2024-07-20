using FluentValidation;
using GerenciamentoBiblioteca.Application.Commands.CreateLivro;

namespace GerenciamentoBiblioteca.Application.Validators
{
    public class CreateLivroValidator : AbstractValidator<CreateLivroCommand>
    {
        public CreateLivroValidator()
        {
            RuleFor(i => i.Titulo)
                .NotEmpty().WithMessage("Informe o título do livro");

            RuleFor(i => i.ISBN)
                .NotEmpty().WithMessage("Informe o ISBN do livro");

            RuleFor(i => i.EmailAddress)
                .NotEmpty().WithMessage("Informe o Email do livro")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(i => i.AnoPublicacao)
                .NotNull().WithMessage("Informe o ano de publicação do livro");

        }
    }
}
