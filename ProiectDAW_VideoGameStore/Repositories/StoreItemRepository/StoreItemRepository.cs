using Microsoft.EntityFrameworkCore;
using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.StoreItemRepository
{
    public class StoreItemRepository : GenericRepository<StoreItem>, IStoreItemRepository
    {
        DbSet<Review> _reviews;   
        public StoreItemRepository(DataBaseContext context) : base(context) 
        {
            _reviews = context.Set<Review>();
        }
        public List<ItemWithAverageReviewScore> GetItemsWithAverageReviewScores()
        {
            var result = from itemStore in _table
                         join review in _reviews on itemStore.Id equals review.StoreItemId into itemReview
                         select new ItemWithAverageReviewScore
                         {
                             IdItem = itemStore.Id,
                             Title = itemStore.Title,
                             Description = itemStore.Description,
                             Price = itemStore.Price,
                             ImageUrl = itemStore.ImageUrl,
                             Score = itemReview.Any() ? itemReview.Average(r => r.Grade) : 0
                         };
            return result.ToList();
        }
    }
}
