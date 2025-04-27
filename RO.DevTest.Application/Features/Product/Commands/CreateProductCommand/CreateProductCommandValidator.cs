using FluentValidation;

namespace RO.DevTest.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(cpau => cpau.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("O campo nome precisa ser preenchido");
        
        RuleFor(cpau => cpau.Name)
            .MaximumLength(60)
            .MinimumLength(3)
            .WithMessage("O campo nome precisa ter entre 3 e 60 caracteres");

    }
}