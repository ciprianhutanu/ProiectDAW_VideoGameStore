using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.Enums;

namespace ProiectDAW_VideoGameStore.Services.OrderServices
{
    public interface IOrderServices
    {
        Task<List<Order>> GetOrdersByUserID(Guid userId);
        void CreateActiveOrder(Guid userId);
        void PlaceOrder(Guid userId);
        void CompleteOrder(Guid orderId);
        void ChangePaymentMethod(Guid orderId, PayTypeEnum paytype);
    }
}
