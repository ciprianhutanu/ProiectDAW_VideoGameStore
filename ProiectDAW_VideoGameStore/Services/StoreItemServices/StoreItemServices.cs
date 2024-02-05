using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Repositories.ReviewRepository;
using ProiectDAW_VideoGameStore.Repositories.StoreItemRepository;

namespace ProiectDAW_VideoGameStore.Services.StoreItemServices
{
    public class StoreItemServices : IStoreItemServices
    {
        IStoreItemRepository _itemsRepo;
        IReviewRepository _reviewRepo;
        public StoreItemServices(IStoreItemRepository itemsRepo, IReviewRepository reviewRepo)
        {
            _itemsRepo = itemsRepo;
            _reviewRepo = reviewRepo;
        }
        public List<ItemWithAverageReviewScore> GetItemsWithAverageReviewScores()
        {
            return _itemsRepo.GetItemsWithAverageReviewScores();
        }

        public List<Review> GetReviewsByStoreItemId(Guid idItem)
        {
            return _reviewRepo.GetReviewsByStoreItemId(idItem); 
        }
    }
}
