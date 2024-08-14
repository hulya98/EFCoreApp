using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.Domain.Dtos.Currency;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Abstract
{
    public interface ICurrencyService
    {
        Task<List<CurrencyViewDto>> GetAll();
        Task<CurrencyViewDto> Add(CurrencyIUDRequest request);
        Task<CurrencyViewDto> Update(CurrencyIUDRequest request);
        Task Delete(List<int> request);

    }
}
