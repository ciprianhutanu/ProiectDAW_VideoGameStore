using ProiectDAW_VideoGameStore.Models.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectDAW_VideoGameStore.Models
{
    public class Review:GenericBase
    {
        [Range(1,10,ErrorMessage = "Grade must be between 1 to 10.")]
        public int Grade {  get; set; }
        public string? Text { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public StoreItem StoreItem { get; set; }
        public Guid StoreItemId { get; set; }
    }
}
