using System.ComponentModel.DataAnnotations;

namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class ReviewDTO
    {
        [Range(1, 10, ErrorMessage = "Grade must be between 1 to 10.")]
        public int Grade { get; set; }
        public string? Text { get; set; }
        public Guid UserId { get; set; }
        public Guid StoreItemId { get; set; }
    }
}
