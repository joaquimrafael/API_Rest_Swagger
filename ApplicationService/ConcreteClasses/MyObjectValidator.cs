using FluentValidation;

namespace ApplicationService
{
    public class MyObjectValidator : AbstractValidator<MyObject>
    {
        public MyObjectValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("O nome é obrigatório");

            RuleFor(x => x.id)
                .Must(id => int.TryParse(id, out _))
                .WithMessage("Id deve ser um número");

            RuleFor(x => x.date)
                .NotEmpty().WithMessage("A data é obrigatória")
                .Must(date => DateOnly.TryParse(date, out _))
                .WithMessage("A data deve estar no formato: yyyy-MM-dd");

            RuleFor(x => x.email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .EmailAddress().WithMessage("Email deve ser válido");

            RuleFor(x => x.programmer)
                .Must(programmer => bool.TryParse(programmer, out _))
                .WithMessage("Programador deve ser booleano (true/false)");
        }
    }
}
