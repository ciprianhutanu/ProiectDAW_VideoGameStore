namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class PlacedOnDTO
    {
        public int ItemQuantity { get; set; }
        public Guid StoreItemId { get; set; }
        public Guid OrderId { get; set; }
    }
}
