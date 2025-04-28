using MediatR;

namespace RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerCommandRequest : IRequest<CreateCustomerResult>
{
    public string UserName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PasswordConfirmation { get; set; } = string.Empty;
    
    public Domain.Entities.User AssignToUser()
    {
        return new Domain.Entities.User
        {
            UserName = UserName,
            Email = Email,
            Name = Name,
        };
    }
    
}