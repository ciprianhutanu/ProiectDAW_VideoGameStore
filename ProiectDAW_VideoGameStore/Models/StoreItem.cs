using ProiectDAW_VideoGameStore.Models.Generic;

namespace ProiectDAW_VideoGameStore.Models
{
    public class StoreItem : GenericBase
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<PlacedOn> PlacedOnOrders{ get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
