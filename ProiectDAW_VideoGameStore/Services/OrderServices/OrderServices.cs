using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Models.Enums;
using ProiectDAW_VideoGameStore.Repositories.OrderRepository;
using ProiectDAW_VideoGameStore.Repositories.UserRepository;

namespace ProiectDAW_VideoGameStore.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        public readonly IUserRepository _userRepo;
        public readonly IOrderRepository _orderRepo;
        
        public OrderServices(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepo = userRepository;
            _orderRepo = orderRepository;
        }

        public async void ChangePaymentMethod(Guid orderId, PayTypeEnum paytype)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order != null)
            {
                order.PayType = paytype;
                _orderRepo.Update(order);
                await _orderRepo.SaveAsync();
            }
        }

        public async void CompleteOrder(Guid orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if(order != null)
            {
                order.Status = Models.Enums.OrderStatus.Done;
                _orderRepo.Update(order);
                await _orderRepo.SaveAsync();
            }
        }

        public async void CreateActiveOrder(Guid userId)
        {
            var user = await _userRepo.FindByIdAsync(userId);
            if (user != null) {
                var newOrder = new Order
                {
                    Id = Guid.NewGuid(),
                    Status = Models.Enums.OrderStatus.Active,
                    UserId = userId,
                    User = user
                };
                await _orderRepo.CreateAsync(newOrder);
                user.ActiveOrderId = newOrder.Id;
                _userRepo.Update(user);

                await _orderRepo.SaveAsync();
                await _userRepo.SaveAsync();
            }
        }

        public async Task<List<Order>> GetOrdersByUserID(Guid userId)
        {
            return await _orderRepo.GetOrdersByUserID(userId);
        }

        public async void PlaceOrder(Guid userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if(user != null && user.ActiveOrderId != default(Guid))
            {
                var order = await _orderRepo.GetByIdAsync(user.ActiveOrderId);
                if(order != null)
                {
                    order.Status = Models.Enums.OrderStatus.Placed;
                    _orderRepo.Update(order);
                    await _orderRepo.SaveAsync();
                }
                user.ActiveOrderId = default(Guid);
                _userRepo.Update(user);
                await _userRepo.SaveAsync();
            }
        }
    }
}
