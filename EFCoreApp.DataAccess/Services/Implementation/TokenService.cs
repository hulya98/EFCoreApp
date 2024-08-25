using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.Domain.Dtos.Account;
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
        private const string TokenSecret = "ForTheLoveOfStoreAndLoadThisSecurity";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(8);

        public string GenerateToken(TokenGenerationRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,request.Email),
                new Claim(JwtRegisteredClaimNames.Email,request.Email),
                new("userId",request.UserId.ToString())
            };

            foreach (var claimPair in request.CustomClaims)
            {
                var jsonElement = (JsonElement)claimPair.Value;
                var valueType = jsonElement.ValueKind switch
                {
                    JsonValueKind.True => ClaimValueTypes.Boolean,
                    JsonValueKind.False => ClaimValueTypes.Boolean,
                    JsonValueKind.Number => ClaimValueTypes.Double,
                    _ => ClaimValueTypes.String
                };

                var claim = new Claim(claimPair.Key, claimPair.Value.ToString()!, valueType);
                claims.Add(claim);
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Issuer = "https://id.nickchapsas.com",
                Audience = "https://movies.nickhapsas.com",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}

