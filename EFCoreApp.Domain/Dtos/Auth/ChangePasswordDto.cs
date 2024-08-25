using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.Auth
{
    public class ChangePasswordDto
    {
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
