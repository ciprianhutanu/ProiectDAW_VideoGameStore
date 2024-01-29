using ProiectDAW_VideoGameStore.Models.Enums;

namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
