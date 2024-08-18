using AutoMapper;
using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.UnitOfWork;
using EFCoreApp.Domain.Dtos.Currency;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Concrete
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyService(ICurrencyRepository repository,
                               IMapper mapper,
                               IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _currencyRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Delete(List<int> request)
        {
            foreach (int id in request)
                await _currencyRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CurrencyViewDto>> GetAll()
        {
            var data = await _currencyRepository.GetAll();
            var map = _mapper.Map<List<CurrencyViewDto>>(data);
            return map;
        }

        public async Task<CurrencyViewDto> Add(CurrencyIUDRequest request)
        {
            var map = _mapper.Map<Currency>(request);
            var data = await _currencyRepository.Add(map);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CurrencyViewDto>(data);
        }

        public async Task<CurrencyViewDto> Update(CurrencyIUDRequest request)
        {
            var map = _mapper.Map<Currency>(request);
            var data = await _currencyRepository.Update(map);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CurrencyViewDto>(data);
        }
    }
}
