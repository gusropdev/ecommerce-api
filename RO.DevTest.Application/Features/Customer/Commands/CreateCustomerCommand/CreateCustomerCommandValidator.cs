using FluentValidation;

namespace RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommandRequest>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(request => request.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("O campo e-mail precisa ser preenchido");

        RuleFor(request => request.Email)
            .EmailAddress()
            .WithMessage("O campo e-mail precisa ser um e-mail válido");

        RuleFor(request => request.Password)
            .MinimumLength(6)
            .WithMessage("O campo senha precisa ter, pelo menos, 6 caracteres");

        RuleFor(request => request.PasswordConfirmation)
            .Matches(request => request.Password)
            .WithMessage("O campo de confirmação de senha deve ser igual ao campo senha");
    }
}