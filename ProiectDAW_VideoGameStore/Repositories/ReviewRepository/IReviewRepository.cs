using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.ReviewRepository
{
    public interface IReviewRepository: IGenericRepository<Review>
    {
        List<Review> GetReviewsByStoreItemId(Guid itemId);
    }
}
