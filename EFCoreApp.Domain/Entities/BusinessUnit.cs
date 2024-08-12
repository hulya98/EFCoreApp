using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Entities
{
    public class BusinessUnit : BaseEntity
    {
        public int BusinessUnitId { get; set; }
        public string BusinessUnitCode { get; set; }
        public string BusinessUnitName { get; set; }
        public int BaseCurrencyId { get; set; }
        public Currency BaseCurrency { get; set; }
        public int ReportCurrencyId { get; set; }
        public Currency ReportCurrency { get; set; }
    }
}
