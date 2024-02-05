using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Models.Enums;

namespace ProiectDAW_VideoGameStore.Services.OrderServices
{
    public interface IOrderServices
    {
        Task<List<Order>> GetOrdersByUserID(Guid userId);
        void PlaceOrder(Guid userId);
        void CompleteOrder(Guid orderId);
        void ChangePaymentMethod(Guid orderId, PayTypeEnum paytype);
        Task<bool> CreateActiveOrder(Guid userId);
        Task<int> GetTotalCost(Guid orderId);
        Task <bool> DropActiveOrder(Guid userId);
        Task<bool> AddItemToOrder(Guid orderId, Guid itemId, int quantity);
        Task<OrderWithTotalDTO> GetOrderWithTotal(Guid orderId);
        Task<List<OrderItems>> GetProductsForOrder(Guid orderId);

    }
}
