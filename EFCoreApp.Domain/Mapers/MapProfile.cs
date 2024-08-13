using AutoMapper;
using EFCoreApp.Domain.Dtos;
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
            #endregion
        }
    }
}
