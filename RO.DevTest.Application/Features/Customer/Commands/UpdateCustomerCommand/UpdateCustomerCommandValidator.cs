using FluentValidation;

namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommandRequest>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O identificador do cliente é obrigatório.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O novo e-mail é obrigatório.")
            .EmailAddress().WithMessage("O novo e-mail deve ser válido.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O novo nome é obrigatório.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("O novo nome de usuário é obrigatório.");
    }
}