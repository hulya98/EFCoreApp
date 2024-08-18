using EFCoreApp.Domain.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Abstract
{
    public interface IAccountService
    {
        public Task<LoginResponse> Authenticate(LoginRequest request);
    }
}
