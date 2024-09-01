using EFCoreApp.Domain.Dtos.Account;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Abstract
{
    public interface ITokenService
    {
        Task<string> GenerateToken(TokenGenerationRequest request, AppUser user);
    }
}
