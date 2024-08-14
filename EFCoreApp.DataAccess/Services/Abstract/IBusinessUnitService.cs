using EFCoreApp.Domain.Dtos.BusinessUnit;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Abstract
{
    public interface IBusinessUnitService
    {
        Task<List<BusinessUnitViewDto>> GetAll();
        Task<List<BusinessUnitCurrency>> GetAllWithCurrency();
        Task<BusinessUnitViewDto> Add(BusinessUnitIUDRequest request);
        Task<BusinessUnitViewDto> Update(BusinessUnitIUDRequest request);
        Task Delete(List<int> request);
    }
}
