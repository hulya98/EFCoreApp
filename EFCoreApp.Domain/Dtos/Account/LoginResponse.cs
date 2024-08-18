using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.Account
{
    public class LoginResponse
    {
        public string JWTToken { get; set; }
    }
}
