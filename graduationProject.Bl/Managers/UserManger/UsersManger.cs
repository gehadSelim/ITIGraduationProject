﻿using graduationProject.Bl.DTOs;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.Managers
{
    public class UsersManger : IUsersManger
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersManger(IConfiguration configuration , UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<TokenDTO> Login(LoginDTO loginDTO)
        {
            ApplicationUser? user;
            if(loginDTO.UserName == null)
            {
                throw new Exception("You Have to Enter UserName Or Email");

            }

            user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(loginDTO.UserName);
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
            }
            
            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if (!isPasswordCorrect)
            {
                throw new Exception("Invalid UserName Or Password");
            }

            var claimsList = await _userManager.GetClaimsAsync(user);

            return GenerateToken(claimsList);
        }

        private TokenDTO GenerateToken(IList<Claim> claimsList)
        {
            var keyString = _configuration["SecretKey"] ?? string.Empty;
            var keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddDays(365);

            var jwt = new JwtSecurityToken(
                    expires: expiry,
                    claims: claimsList,
                    signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return new TokenDTO(
                    tokenString,
                    claimsList.FirstOrDefault(c=> c.Type == ClaimTypes.UserData).Value,
                    claimsList.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                    expiry
                );
        }
    }
}