using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Models.Enums;
using ProiectDAW_VideoGameStore.Repositories.OrderRepository;
using ProiectDAW_VideoGameStore.Repositories.PlacedOnRepository;
using ProiectDAW_VideoGameStore.Repositories.UserRepository;

namespace ProiectDAW_VideoGameStore.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        public readonly IUserRepository _userRepo;
        public readonly IOrderRepository _orderRepo;
        public readonly IPlacedOnRepository _placedOnRepo;
        
        public OrderServices(IUserRepository userRepository, IOrderRepository orderRepository, IPlacedOnRepository placedOnRepo)
        {
            _userRepo = userRepository;
            _orderRepo = orderRepository;
            _placedOnRepo = placedOnRepo;
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

        public async Task<bool> CreateActiveOrder(Guid userId)
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

                return true;
            }
            return false;
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
        public async Task<int> GetTotalCost(Guid orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order != null)
            {
                var OrderProducts = _placedOnRepo.GetItemsFromOrder(orderId);
                return OrderProducts.Sum(op => op.FinalPrice);
            }
            return 0;
        }

        public async Task<OrderWithTotalDTO> GetOrderWithTotal(Guid orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if(order != null)
            {
                return new OrderWithTotalDTO
                {
                    PayType = order.PayType,
                    UserId = order.UserId,
                    Status = order.Status,
                    Total = await GetTotalCost(orderId)
                };
            }
            return null;
        }

        public async Task<List<OrderItems>> GetProductsForOrder(Guid orderId)
        {
            return _placedOnRepo.GetItemsFromOrder(orderId);
        }

        public async Task<bool> DropActiveOrder(Guid userId)
        {
            var user = await _userRepo.FindByIdAsync(userId);
            if (user != null)
            {
                var orderId = user.ActiveOrderId;
                if (orderId != default)
                {
                    _orderRepo.DeleteById(orderId);
                    await _orderRepo.SaveAsync();
                }
                else
                    return false;
            }
            else return false;
            return true;
        }

        public async Task<bool> AddItemToOrder(Guid userId, Guid itemId, int quantity)
        {
            var user = await _userRepo.FindByIdAsync(userId);
            if (user != null)
            {
                var NewPlacedOn = new PlacedOn
                {
                    OrderId = user.ActiveOrderId,
                    StoreItemId = itemId,
                    ItemQuantity = quantity
                };
                await _placedOnRepo.CreateAsync(NewPlacedOn);
                await _placedOnRepo.SaveAsync();
            }
            else { return false; }
            return true;
        }
    }
}
