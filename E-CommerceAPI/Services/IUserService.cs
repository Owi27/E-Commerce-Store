using E_CommerceAPI.DTOs;
using E_CommerceAPI.Models;

namespace E_CommerceAPI.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Register(UserRegisterRequest request);
        Task<ServiceResponse<string>> Login(UserLoginRequest request);
    }
}
