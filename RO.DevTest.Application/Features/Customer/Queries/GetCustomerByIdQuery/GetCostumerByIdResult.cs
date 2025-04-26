using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Application.Features.Customer.Queries.GetCustomerByIdQuery;

public record GetCostumerByIdResult (Guid CustomerId, string Name, string UserName,string Email, List<Order> Orders)
{
    
}