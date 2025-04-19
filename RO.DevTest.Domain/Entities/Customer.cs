using System.ComponentModel.DataAnnotations;

namespace RO.DevTest.Domain.Entities;

public class Customer
{
    [Key]
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public List<Order> Orders { get; set; } = [];

}