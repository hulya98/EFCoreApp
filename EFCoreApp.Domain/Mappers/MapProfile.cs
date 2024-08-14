using AutoMapper;
using EFCoreApp.Domain.Dtos.BusinessUnit;
using EFCoreApp.Domain.Dtos.Currency;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.Domain.Mapers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region curreny
            CreateMap<Currency, CurrencyViewDto>().ReverseMap();
            CreateMap<Currency, CurrencyIUDRequest>().ReverseMap();
            #endregion

            #region businessUnit
            CreateMap<BusinessUnit, BusinessUnitViewDto>().ReverseMap();
            CreateMap<BusinessUnit, BusinessUnitIUDRequest>().ReverseMap();
            #endregion
        }
    }
}
