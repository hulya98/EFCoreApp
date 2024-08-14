using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Repositories.Abstract
{
    public interface IBusinessUnitRepository : IRepository<BusinessUnit>
    {
        public Task<List<BusinessUnitCurrency>> GetAllWithCurrency();
    }
}
