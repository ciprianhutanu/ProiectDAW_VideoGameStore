using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProiectDAW_VideoGameStore.Data;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Repositories.GenericRepository;

namespace ProiectDAW_VideoGameStore.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) { }

        public async Task<List<User>> FindAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<User> FindByUsername(string username)
        {
            return await _table.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }
    }
}
