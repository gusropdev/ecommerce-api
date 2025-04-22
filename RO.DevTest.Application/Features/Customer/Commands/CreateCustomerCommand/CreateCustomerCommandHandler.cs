using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Enums;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerCommandHandler(
    IIdentityAbstractor identityAbstractor,
    ICustomerRepository customerRepository)
    : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerResult>

{
    private readonly IIdentityAbstractor _identityAbstractor = identityAbstractor;
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<CreateCustomerResult> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        var user = request.AssignToUser();
        var creationResult = await _identityAbstractor.CreateUserAsync(user, request.Password);
        if (!creationResult.Succeeded)
            throw new BadRequestException(creationResult);
        
        var roleResult = await _identityAbstractor.AddToRoleAsync(user, UserRoles.Customer);
        if (!roleResult.Succeeded)
            throw new BadRequestException(roleResult);
        
        var customer = new Domain.Entities.Customer
        {
            UserId = user.Id,
            User = user
        };

        await _customerRepository.CreateAsync(customer, cancellationToken);

        return new CreateCustomerResult(customer);
    }
}