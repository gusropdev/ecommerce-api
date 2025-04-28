namespace RO.DevTest.Application.Features.Customer.Queries.GetAllCustomersQuery;

public record GetAllCustomersResult (int TotalCount, List<GetAllCustomersResponseItem> Customers)
{
    
}