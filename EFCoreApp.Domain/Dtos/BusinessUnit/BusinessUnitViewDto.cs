using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Dtos.BusinessUnit
{
    public class BusinessUnitViewDto : BaseEntity
    {
        public int BusinessUnitId { get; set; }
        public string BusinessUnitCode { get; set; }
        public string BusinessUnitName { get; set; }
        public int BaseCurrencyId { get; set; }
        public int ReportCurrencyId { get; set; }
    }
}
