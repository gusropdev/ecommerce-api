namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public record UpdateCustomerResult (string Message, Guid CustomerId, string Address, DateTime? DateOfBirth)
{
    
}