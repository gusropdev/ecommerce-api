namespace RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;

public record CreateCustomerResult
{
    public string CustomerId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public CreateCustomerResult(Domain.Entities.Customer customer)
    {
        CustomerId = customer.UserId;
        UserId = customer.User.Id;
        Email = customer.User.Email!;
        UserName = customer.User.UserName!;
    }
}