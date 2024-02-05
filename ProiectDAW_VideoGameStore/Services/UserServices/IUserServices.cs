using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs.UserDTOs;
using ProiectDAW_VideoGameStore.Models.Enums;

namespace ProiectDAW_VideoGameStore.Services.UserServices
{
    public interface IUserServices
    {
        Task<UserLoginResponse> Login(UserLoginDTO userDTO);
        Task<User> GetById(Guid id);
        Task<bool> Register(UserRegistrationDTO newUser, Role userRole);
        Task<List<User>> GetAllUsers();
    }
}
