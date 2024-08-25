using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.Account
{
    public class TokenGenerationRequest
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public Dictionary<string, object> CustomClaims { get; set; }
    }
}
