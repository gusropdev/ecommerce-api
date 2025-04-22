using System.Globalization;
using MediatR;
using RO.DevTest.Application.Contracts.Persistance.Repositories;

namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public class UpdateCustomerCommandHandler (ICustomerRepository customerRepository, IUserRepository userRepository) : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer =  await customerRepository.GetAsync(c => c.UserId == request.UserId);
        if (customer == null)
            throw new CultureNotFoundException("Cliente não encontrado");

        var user = customer.User;
        
        user.Name = request.Name;
        user.Email = request.Email;
        user.UserName = request.UserName;
        
        userRepository.Update(user);
        
        return new UpdateCustomerResult(customer.UserId, user.Name, user.Email, user.UserName);
    }
}