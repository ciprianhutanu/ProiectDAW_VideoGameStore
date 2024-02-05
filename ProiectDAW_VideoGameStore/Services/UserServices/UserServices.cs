using ProiectDAW_VideoGameStore.Helpers.JwtUtils;
using ProiectDAW_VideoGameStore.Models;
using ProiectDAW_VideoGameStore.Models.DTOs.UserDTOs;
using ProiectDAW_VideoGameStore.Models.Enums;
using ProiectDAW_VideoGameStore.Repositories.UserRepository;
using System.Runtime.CompilerServices;


namespace ProiectDAW_VideoGameStore.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtUtils _jwtUtils;

        public UserServices(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepo = userRepository;
            _jwtUtils = jwtUtils;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userRepo.FindByIdAsync(id);
        }

        public async Task<UserLoginResponse> Login(UserLoginDTO userDTO)
        {
            var user = await _userRepo.FindByUsername(userDTO.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userDTO.Password, user.Password))
            {
                return null;
            }
            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserLoginResponse(user, token);

        }

        public async Task<bool> Register(UserRegistrationDTO newUser, Role userRole)
        {
            var UserToCreate = new User
            {
                Username = newUser.Username,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
                Role = userRole
            };
            _userRepo.CreateAsync(UserToCreate);
            return await _userRepo.SaveAsync();
        }
    }
}
