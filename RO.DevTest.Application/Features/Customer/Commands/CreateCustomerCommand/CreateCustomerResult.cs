namespace RO.DevTest.Application.Features.Customer.Commands.CreateCustomerCommand;

public record CreateCustomerResult
{
    public string Message { get; set; } = string.Empty;
    public string CustomerId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public CreateCustomerResult(string message, Domain.Entities.Customer customer)
    {
        CustomerId = customer.UserId;
        UserId = customer.User.Id;
        Email = customer.User.Email!;
        UserName = customer.User.UserName!;
        Message = message;
    }
}