namespace RO.DevTest.Application.Features.Customer.Queries.GetCustomerByIdQuery;

public record GetCustomerByIdResult (Guid CustomerId, string Name, string UserName,string Email, List<Domain.Entities.Order> Orders)
{
    
}