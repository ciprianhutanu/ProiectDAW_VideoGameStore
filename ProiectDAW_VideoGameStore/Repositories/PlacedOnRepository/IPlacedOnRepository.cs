using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.PlacedOnRepository
{
    public interface IPlacedOnRepository: IGenericRepository<PlacedOn>
    {
        List<OrderItems> GetItemsFromOrder(Guid orderId);
    }
}
