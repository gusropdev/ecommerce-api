using System.Globalization;
using System.Linq.Expressions;
using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandHandler (ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer =  await customerRepository.GetAsync(c => c.Id == request.CustomerId);
        if (customer == null)
            throw new BadRequestException("Cliente não encontrado");
        
        customer.Address = request.Address;
        customer.DateOfBirth = request.DateOfBirth;
        
        await customerRepository.UpdateAsync(customer);
        
        return new UpdateCustomerResult("Cliente atualizado com sucesso.", customer.Id, customer.Address, customer.DateOfBirth);
    }
}