using MediatR;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Exception;

namespace RO.DevTest.Application.Features.Customer.Commands.DeleteCustomerCommand;

public class DeleteCustomerCommandHandler (ICustomerRepository customerRepository, IIdentityAbstractor identityAbstractor) 
    : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerResult>
{
    public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetAsync(c => c.Id == request.CustomerId, c => c.User);
        if(customer == null)
            throw new BadRequestException("Cliente não encontrado");
        
        var user = customer.User;
        
        await customerRepository.DeleteAsync(customer);
        await identityAbstractor.DeleteUser(customer.User);
        
        return new DeleteCustomerResult("Cliente apagado com sucesso.", customer.Id, user.Name, user.UserName!,user.Email!);
    }
}