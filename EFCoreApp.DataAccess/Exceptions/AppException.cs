using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Exceptions
{
    public class AppException : Exception
    {
        private readonly string message;
        public AppException(string message) 
        {
            this.message = message;
        }

        public override string Message => message;
        public override IDictionary Data => base.Data;
    }
}
