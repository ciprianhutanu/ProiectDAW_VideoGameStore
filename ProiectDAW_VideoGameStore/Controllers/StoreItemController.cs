using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs;
using ProiectDAW_VideoGameStore.Services.StoreItemServices;

namespace ProiectDAW_VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreItemController : ControllerBase
    {
        private readonly IStoreItemServices _storeItemServices;
        
        public StoreItemController(IStoreItemServices storeItemServices)
        {
            _storeItemServices = storeItemServices;
        }

        [Authorize(Roles = "Employee")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateItem([FromBody] StoreItemDTO storeItemDTO)
        {
            var response = await _storeItemServices.CreateItem(storeItemDTO);
            if(response == false)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [Authorize(Roles = "Employee")]
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateItem([FromBody] StoreItemDTO storeItemDTO)
        {
            var response = await _storeItemServices.UpdateItem(storeItemDTO);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [Authorize(Roles = "Employee")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteItem([FromBody] StoreItemDTO storeItemDTO)
        {
            var response = await _storeItemServices.DeleteItem(storeItemDTO);
            if (response == false)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
