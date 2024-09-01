using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.Domain.Dtos.Account;
using EFCoreApp.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(TokenGenerationRequest request, AppUser user)
        {
            string result = "";
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["Token:Audience"],
                Issuer = _configuration["Token:Issuer"],
                Expires = DateTime.Now.AddHours(1),
                NotBefore = DateTime.UtcNow,
                Subject = new ClaimsIdentity(await GetUserClaimsAsync(request)),
                SigningCredentials = signingCredentials,
                

            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            result = tokenHandler.WriteToken(securityToken);
            return result;

        }

        public async Task<List<Claim>> GetUserClaimsAsync(TokenGenerationRequest user)
        {
            var claims = await Task.Run(() =>
            {
                var value = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name,user.Email.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString())
                    };
                return value;
            });

            return claims;
        }
    }

}

