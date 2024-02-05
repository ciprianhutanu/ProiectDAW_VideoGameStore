using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW_VideoGameStore.Models.DTOs.UserDTOs;
using ProiectDAW_VideoGameStore.Models.Enums;
using ProiectDAW_VideoGameStore.Services.UserServices;
using ProiectDAW_VideoGameStore.Helpers.Attributes;

namespace ProiectDAW_VideoGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices) 
        {
            _userServices = userServices;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var response = await _userServices.Login(userLoginDTO);
            if(response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRegistrationDTO userRegistrationDTO)
        {
            var response = await _userServices.Register(userRegistrationDTO, Models.Enums.Role.Customer);
            if(response == false)
            {
                return BadRequest();
            }
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee(UserRegistrationDTO userRegistrationDTO)
        {
            var response = await _userServices.Register(userRegistrationDTO, Models.Enums.Role.Employee);

            if (response == false)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [Authorize]
        [HttpGet("check-auth-without-role")]
        public IActionResult GetText()
        {
            return Ok(new { Message = "Account is logged in" });
        }


        [Authorize(Role.Customer)]
        [HttpGet("check-auth-customer")]
        public IActionResult GetTextCustomer()
        {
            return Ok(new { Message = "Customer is logged in" });
        }

        [Authorize(Role.Employee)]
        [HttpGet("check-auth-employee")]
        public IActionResult GetTextEmployee()
        {
            return Ok(new { Message = "Employee is logged in" });
        }


    }
}
