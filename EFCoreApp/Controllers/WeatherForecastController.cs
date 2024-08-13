using EFCoreApp.DataAccess.Repositories.Abstract;
using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.DataAccess.Services.Concrete;
using EFCoreApp.Domain;
using EFCoreApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly ICurrencyService _currencyService;
        public WeatherForecastController(
            //ICurrencyService currencyService
            )
        {
            //_currencyService = currencyService;
        }
        //[HttpGet(Name = "GetWeatherForecast")]
        //public async Task<IEnumerable<Currency>>? Get()
        //{
        //    var cc = await _currencyService.ge();
        //    return cc;
        //}
    }
}
