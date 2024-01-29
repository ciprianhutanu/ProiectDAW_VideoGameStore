using ProiectDAW_VideoGameStore.Models.Generic;

namespace ProiectDAW_VideoGameStore.Models
{
    public class PlacedOn:GenericBase
    {
        public int ItemQuantity { get; set; }
        public StoreItem StoreItem { get; set; }
        public Guid StoreItemId { get; set; }

        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
