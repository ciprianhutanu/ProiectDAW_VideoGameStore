namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class StoreItemDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public required byte[] ImageData { get; set; }

    }
}
