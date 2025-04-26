namespace RO.DevTest.Application.Features.Customer.Queries.GetAllCustomersQuery;

public record GetAllCustomersResponseItem(Guid CustomerId, string Name, string UserName, string Email)
{
    
}