using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.Auth
{
    public sealed record RegisterDto(
        string Email, string UserName, string FirstName, string LastName, string Password)
    {

    }
}
