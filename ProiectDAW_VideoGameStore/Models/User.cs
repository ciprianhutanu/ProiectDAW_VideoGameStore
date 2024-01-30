using ProiectDAW_VideoGameStore.Models.Enums;
using ProiectDAW_VideoGameStore.Models.Generic;
using System.Text.Json.Serialization;

namespace ProiectDAW_VideoGameStore.Models
{
    public class User:GenericBase
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username {  get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
        public Role Role { get; set; }

        public Guid ActiveOrderId { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
