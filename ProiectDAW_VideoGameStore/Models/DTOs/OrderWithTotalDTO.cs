using ProiectDAW_VideoGameStore.Models.Enums;

namespace ProiectDAW_VideoGameStore.Models.DTOs
{
    public class OrderWithTotalDTO
    {
        public PayTypeEnum PayType { get; set; }
        public OrderStatus Status { get; set; }
        public int Total { get; set; }
        public Guid UserId { get; set; }
    }
}
