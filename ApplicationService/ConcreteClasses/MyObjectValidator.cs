using FluentValidation;


namespace ApplicationService
{
    public class MyObjectValidator : AbstractValidator<MyObject>
    {
        public MyObjectValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("O nome é obrigatorio");

            RuleFor(x => x.id)
                .Must(id => int.TryParse(id, out _))
                .WithMessage("Id deve ser um número");

            RuleFor(x => x.date)
                .NotEmpty().WithMessage("O Id é obrigatorio")
                .Must(date => DateOnly.TryParse(date, out _))
                .WithMessage("A string deve estar no Formato: yyyy--mm--dd");

            RuleFor(x => x.email)
                .NotEmpty().WithMessage("O email é obrigatorio")
                .EmailAddress().WithMessage("Email deve ser válido");

        }
    }
}
