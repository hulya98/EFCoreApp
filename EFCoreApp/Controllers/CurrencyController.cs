using EFCoreApp.DataAccess.Services.Abstract;
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
            return CreateActionResult(new ApiResponse<Currency>(200, data, "success"));
        }
    }
}
