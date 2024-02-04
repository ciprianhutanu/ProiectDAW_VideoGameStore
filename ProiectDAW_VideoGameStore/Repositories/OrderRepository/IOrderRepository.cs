using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.OrderRepository
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserID(Guid userID);
    }
}
