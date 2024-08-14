using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.Domain.Dtos.Currency;
using EFCoreApp.Domain.Entities;
using EFCoreApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : CustomBaseController
    {
        private readonly ICurrencyService currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await currencyService.GetAll();
            return CreateActionResult(new ApiResponse<List<CurrencyViewDto>>(200, data, "success"));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CurrencyIUDRequest request)
        {
            var data = await currencyService.Add(request);
            return CreateActionResult(new ApiResponse<CurrencyViewDto>(200,data,""));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CurrencyIUDRequest request)
        {
            var data = await currencyService.Update(request);
            return CreateActionResult(new ApiResponse<CurrencyViewDto>(200, data, ""));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(List<int> ids)
        {
            await currencyService.Delete(ids);
            return CreateActionResult(new ApiResponse<bool>(200, true, "success"));
        }
    }
}
