using AutoMapper;
using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Repositories.Concrete;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.UnitOfWork;
using EFCoreApp.Domain.Dtos.BusinessUnit;
using EFCoreApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreApp.DataAccess.Services.Concrete
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IBusinessUnitRepository _businessUnitRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BusinessUnitService(IBusinessUnitRepository businessUnitRepository,
                                   IMapper mapper,
                                   IUnitOfWork unitOfWork)
        {
            _businessUnitRepository = businessUnitRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BusinessUnitViewDto> Add(BusinessUnitIUDRequest request)
        {
            var map = _mapper.Map<BusinessUnit>(request);
            var data = await _businessUnitRepository.Add(map);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<BusinessUnitViewDto>(data);
        }

        public async Task Delete(List<int> request)
        {
            foreach (int id in request)
                await _businessUnitRepository.Delete(id);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<BusinessUnitViewDto>> GetAll()
        {
            var data = await _businessUnitRepository.GetAll();
            var map = _mapper.Map<List<BusinessUnitViewDto>>(data);
            return map;
        }

        public async Task<List<BusinessUnitCurrency>> GetAllWithCurrency()
        {
            var data = await _businessUnitRepository.GetAllWithCurrency();
            return data;
        }

        public async Task<BusinessUnitViewDto> Update(BusinessUnitIUDRequest request)
        {
            var map = _mapper.Map<BusinessUnit>(request);
            var data = _businessUnitRepository.Add(map);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<BusinessUnitViewDto>(data);
        }
    }
}
