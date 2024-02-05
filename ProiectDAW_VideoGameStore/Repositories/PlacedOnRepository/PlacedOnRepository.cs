using Microsoft.EntityFrameworkCore;
using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.PlacedOnRepository
{
    public class PlacedOnRepository : GenericRepository<PlacedOn>, IPlacedOnRepository
    {
        DbSet<StoreItem> _storeItems;
        public PlacedOnRepository(DataBaseContext context):base(context) 
        {
            _storeItems = context.Set<StoreItem>();
        }
        public List<OrderItems> GetItemsFromOrder(Guid orderId)
        {
            var result = from placedOnList in _table
                         join storeItems in _storeItems on placedOnList.StoreItemId equals storeItems.Id
                         where placedOnList.OrderId == orderId
                         select new OrderItems
                         {
                             Title = storeItems.Title,
                             Quantity = placedOnList.ItemQuantity,
                             FinalPrice = placedOnList.ItemQuantity * storeItems.Price
                         };
            return result.ToList();
        }
    }
}
