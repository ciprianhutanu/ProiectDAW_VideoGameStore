using ProiectDAW_VideoGameStore.Models.Enums;

namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class OrderDTO
    {
        public PayTypeEnum PayType { get; set; }
        public Guid UserId { get; set; }
    }
}
