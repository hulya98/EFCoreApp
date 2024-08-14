using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.Currency
{
    public class CurrencyIUDRequest
    {
        public int CurrencyId { get; set; }
        public string CurrencyKey { get; set; }
        public string CurrencyName { get; set; }
    }
}
