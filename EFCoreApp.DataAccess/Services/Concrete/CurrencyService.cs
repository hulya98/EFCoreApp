using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Concrete
{
    public class CurrencyService : Service<Currency>, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(ICurrencyRepository repository) : base(repository)
        {
            _currencyRepository = repository;
        }

    }
}
