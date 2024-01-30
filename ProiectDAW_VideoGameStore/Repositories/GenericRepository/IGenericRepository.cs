using ProiectDAW_VideoGameStore.Models.Generic;

namespace ProiectDAW_VideoGameStore.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : GenericBase
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteById(Guid id);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<TEntity> FindByIdAsync(Guid id);
        Task<bool> SaveAsync();
    }
}
