using System.ComponentModel.DataAnnotations;
using RO.DevTest.Domain.Abstract;

namespace RO.DevTest.Domain.Entities;

public class Customer : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
    public List<Order> Orders { get; set; } = [];

}