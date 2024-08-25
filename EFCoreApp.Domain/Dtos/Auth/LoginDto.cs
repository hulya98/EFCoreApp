using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.Auth
{
    public sealed record LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }

    }
}
