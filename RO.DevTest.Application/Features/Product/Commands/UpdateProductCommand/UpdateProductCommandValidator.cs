using FluentValidation;

namespace RO.DevTest.Application.Features.Product.Commands.UpdateProductCommand;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(request => request.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("O campo nome precisa ser preenchido");
        
        RuleFor(request => request.Name)
            .MaximumLength(60)
            .MinimumLength(3)
            .WithMessage("O campo nome precisa ter entre 3 e 60 caracteres");

        RuleFor(request => request.Description)
            .MaximumLength(300);
        
        RuleFor(request => request.Price)
            .GreaterThan(0);

        RuleFor(request => request.StockQuantity)
            .GreaterThanOrEqualTo(0);
    }
}