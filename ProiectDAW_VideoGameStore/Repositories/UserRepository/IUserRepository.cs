using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<User> FindByUsername(string username);
        Task<List<User>> FindAll();
    }
}
