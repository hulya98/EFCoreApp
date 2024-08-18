using EFCoreApp.DataAccess.Services.Abstract;
using EFCoreApp.Domain.Dtos.Account;
using EFCoreApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : CustomBaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            var response = await _accountService.Authenticate(loginRequest);
            return CreateActionResult(new ApiResponse<LoginResponse>(200, response, "Success"));
        }
    }
}
