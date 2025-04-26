namespace RO.DevTest.Application.Features.Customer.Commands.UpdateCustomerCommand;

public record UpdateCustomerResult (Guid CustomerId, string Address, DateTime? DateOfBirth)
{
    
}