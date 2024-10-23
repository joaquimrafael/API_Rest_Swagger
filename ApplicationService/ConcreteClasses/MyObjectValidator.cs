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
                .Must(date => DateOnly.TryParse(date, out _))
                .WithMessage("A string deve estar no Formato: yyyy--mm--dd");

        }
    }
}
