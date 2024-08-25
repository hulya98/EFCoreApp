using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.Services.Concrete;
using EFCoreApp.Domain.Dtos.BusinessUnit;
using EFCoreApp.Domain.Entities;
using EFCoreApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreApp.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessUnitController : CustomBaseController
    {
        private readonly IBusinessUnitService _businessUnitService;
        public BusinessUnitController(IBusinessUnitService businessUnitService)
        {
            _businessUnitService = businessUnitService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _businessUnitService.GetAll();
            return CreateActionResult(new ApiResponse<List<BusinessUnitViewDto>>
                (200, data, "success"));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllWithCurrency()
        {
            var data = await _businessUnitService.GetAllWithCurrency();
            return CreateActionResult(new ApiResponse<List<BusinessUnitCurrency>>
                (200, data, "success"));
        }

        [HttpPost]
        public async Task<IActionResult> Add(BusinessUnitIUDRequest request)
        {
            var data = await _businessUnitService.Add(request);
            return CreateActionResult(new ApiResponse<BusinessUnitViewDto>(200, data, ""));
        }


        [HttpPut]
        public async Task<IActionResult> Update(BusinessUnitIUDRequest request)
        {
            var data = await _businessUnitService.Update(request);
            return CreateActionResult(new ApiResponse<BusinessUnitViewDto>(200, data, ""));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            await _businessUnitService.Delete(ids);
            return CreateActionResult(new ApiResponse<bool>(200, true, "success"));
        }


    }
}
