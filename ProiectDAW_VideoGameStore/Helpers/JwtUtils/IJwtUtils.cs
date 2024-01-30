using ProiectDAW_VideoGameStore.Models;

namespace ProiectDAW_VideoGameStore.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid? GetUserId(string? token);
    }
}
