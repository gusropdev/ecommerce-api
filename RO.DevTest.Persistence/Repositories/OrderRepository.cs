using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Repositories;

public class OrderRepository (DefaultContext context): BaseRepository<Order>(context), IOrderRepository
{
    
}