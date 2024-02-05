using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;

namespace ProiectDAW_VideoGameStore.Services.StoreItemServices
{
    public interface IStoreItemServices
    {
        List<ItemWithAverageReviewScore> GetItemsWithAverageReviewScores();
        List<Review> GetReviewsByStoreItemId(Guid idItem);
    }
}
