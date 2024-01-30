using System.ComponentModel.DataAnnotations;

namespace ProiectDAW_VideoGameStore.Models.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
