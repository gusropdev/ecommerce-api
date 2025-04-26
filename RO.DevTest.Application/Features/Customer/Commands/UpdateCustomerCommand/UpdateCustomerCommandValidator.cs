using FluentValidation;

namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommandRequest>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull()
            .WithMessage("O id do cliente é obrigatório.");
        
    }
}