﻿using Azure.Core;
using E_CommerceAPI.Data;
using E_CommerceAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace E_CommerceAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public UserService(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(UserLoginRequest request)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == request.Email.ToLower());
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User doesn't Exist";
                return serviceResponse;
            }

            if (user.VerifiedAt == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Please Verify Account";
                return serviceResponse;
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Wrong Password Entered";
                return serviceResponse;
            }

            serviceResponse.Data = CreateToken(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterRequest request)
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

        public async Task<ServiceResponse<string>> Verify(string token)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid Token";
                return serviceResponse;
            }
            user.VerifiedAt = DateTime.Now;
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = user.VerifiedAt.ToString();

            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> ForgotPassword(string email)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }
            //Send email to reset pass

            user.PasswordResetToken = Guid.NewGuid().ToString();
            user.ResetTokenExpiration = DateTime.Now.AddDays(1);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = user.ResetTokenExpiration.ToString();

            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> ResetPassword(ResetPasswordRequest request)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            if (user == null || user.ResetTokenExpiration < DateTime.Now)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Invalid Token";
                return serviceResponse;
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpiration = null;
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = "Password Successfully Reset";

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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            //Create a list of claims to store user info
            var claims = new List<Claim>
            {
                //Add a claim for the user's unique identifier
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                //Add a claim for the user's username
                new Claim(ClaimTypes.Email, user.Email)
            };

            //Retrieve the token value from the app settings in the config
            var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value;
            if (appSettingsToken is null)
                throw new Exception("AppSettings Token is null!");

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(appSettingsToken));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}