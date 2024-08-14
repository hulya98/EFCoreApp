using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.Domain;
using EFCoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Repositories.Concrete
{
    public class BusinessUnitRepository : Repository<BusinessUnit>, IBusinessUnitRepository
    {
        Context _context;
        public BusinessUnitRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<BusinessUnitCurrency>> GetAllWithCurrency()
        {
            var data = await _context.BusinessUnitCurrencies.ToListAsync();
            return data;
        }
    }
}
