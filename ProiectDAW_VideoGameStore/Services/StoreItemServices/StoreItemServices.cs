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

        public async Task<bool> CreateItem(StoreItemDTO storeItemDTO)
        {
            var NewStoreItem = new StoreItem
            {
                Title = storeItemDTO.Title,
                Description = storeItemDTO.Description,
                ImageUrl = storeItemDTO.ImageUrl,
                Price = storeItemDTO.Price
            };
            await _itemsRepo.CreateAsync(NewStoreItem);
            await _itemsRepo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteItem(StoreItemDTO storeItemDTO)
        {
            var items = await _itemsRepo.GetAllAsync();
            var item = items.FirstOrDefault(it => it.Title == storeItemDTO.Title);
            if(item != null)
            {
                _itemsRepo.Delete(item);
                return true;
            }
            return false;
        }

        public List<ItemWithAverageReviewScore> GetItemsWithAverageReviewScores()
        {
            return _itemsRepo.GetItemsWithAverageReviewScores();
        }

        public List<Review> GetReviewsByStoreItemId(Guid idItem)
        {
            return _reviewRepo.GetReviewsByStoreItemId(idItem); 
        }

        public async Task<bool> UpdateItem(StoreItemDTO storeItemDTO)
        {
            var items = await _itemsRepo.GetAllAsync();
            var item = items.FirstOrDefault(it => it.Title == storeItemDTO.Title);
            if(item != null)
            {
                item.Title = storeItemDTO.Title;
                item.Price = storeItemDTO.Price;
                item.Description = storeItemDTO.Description;
                item.ImageUrl = storeItemDTO.ImageUrl;

                _itemsRepo.Update(item);
                return true;
            }
            return false;
        }
    }
}
