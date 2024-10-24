using FluentValidation;


namespace ApplicationService
{
    public class MyObjectValidator : AbstractValidator<MyObject>
    {
        public MyObjectValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("O nome é obrigatorio");

            RuleFor(x => x.id).GreaterThan(0).WithMessage("O Id deve ser maior que 0");

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
