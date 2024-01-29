using ProiectDAW_VideoGameStore.Models.Enums;
using ProiectDAW_VideoGameStore.Models.Generic;

namespace ProiectDAW_VideoGameStore.Models
{
    public class Order:GenericBase
    {
        public PayTypeEnum PayType { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public ICollection<PlacedOn> ItemsPlacedOn { get; set; }
    }
}
