using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.ReviewRepository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DataBaseContext context):base(context) { }
        public List<Review> GetReviewsByStoreItemId(Guid itemId)
        {
            return _table.Where(r => r.StoreItemId == itemId).ToList();
        }
    }
}
