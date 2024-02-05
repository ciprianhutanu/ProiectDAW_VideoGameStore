namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class ItemWithAverageReviewScore
    {
        public Guid IdItem { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set;}
        public double? Score { get; set; }
    }
}
