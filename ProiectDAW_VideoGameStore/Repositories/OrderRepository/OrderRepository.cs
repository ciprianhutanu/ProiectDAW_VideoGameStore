using Microsoft.EntityFrameworkCore;
using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.OrderRepository
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataBaseContext context): base(context) { }
        public async Task<List<Order>> GetOrdersByUserID(Guid userID)
        {
            var orders = _table.Where(or => or.UserId == userID && or.Status == Models.Enums.OrderStatus.Placed).ToListAsync();
            return await orders!;
        }
    }
}
