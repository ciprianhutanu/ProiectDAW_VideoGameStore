using System.ComponentModel.DataAnnotations;

namespace ProiectDAW_VideoGameStore.Models.DTOs.UserDTOs
{
    public class UserRegistrationDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}
