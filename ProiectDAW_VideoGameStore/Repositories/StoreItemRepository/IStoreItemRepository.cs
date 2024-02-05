using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.StoreItemRepository
{
    public interface IStoreItemRepository: IGenericRepository<StoreItem>
    {
        List<ItemWithAverageReviewScore> GetItemsWithAverageReviewScores();
    }
}
