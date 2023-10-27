using E_CommerceAPI.Data;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace E_CommerceAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<int>> RegisterUser(UserRegisterRequest request)
        {
            var serviceResponse = new ServiceResponse<int>();

            if (_dataContext.Users.Any(u => u.Email == request.Email))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User already Exists";
                return serviceResponse;
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = Guid.NewGuid().ToString(),
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = user.ID;
            return serviceResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
