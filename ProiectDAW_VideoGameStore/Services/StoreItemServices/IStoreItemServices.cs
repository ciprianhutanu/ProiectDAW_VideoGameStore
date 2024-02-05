using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;

namespace ProiectDAW_VideoGameStore.Services.StoreItemServices
{
    public interface IStoreItemServices
    {
        Task<bool> CreateItem(StoreItemDTO storeItemDTO);
        Task<bool> UpdateItem(StoreItemDTO storeItemDTO);
        Task<bool> DeleteItem(StoreItemDTO storeItemDTO);
        List<ItemWithAverageReviewScore> GetItemsWithAverageReviewScores();
        List<Review> GetReviewsByStoreItemId(Guid idItem);
    }
}
