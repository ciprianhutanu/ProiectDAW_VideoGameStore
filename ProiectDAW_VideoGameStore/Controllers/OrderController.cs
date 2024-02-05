using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Services.OrderServices;

namespace ProiectDAW_VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost("create-order")]
        [Authorize]
        public async Task<IActionResult> CreateOrder(Guid userId)
        {
            var result = await _orderServices.CreateActiveOrder(userId);
            if(result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("add-item-to-order")]
        [Authorize]
        public async Task<IActionResult> AddItemToOrder(Guid userId, Guid itemId, int quantity)
        {
            var result = await _orderServices.AddItemToOrder(userId, itemId, quantity);
            if(result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete-active-order")]
        [Authorize]
        public async Task<IActionResult> DeleteActiveOrder(Guid userId)
        {
            var result = await _orderServices.DropActiveOrder(userId);
            if(result == false)
            {
                return BadRequest(); 
            }
            return Ok();
        }
    }
}
