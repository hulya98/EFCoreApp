using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController(RoleManager<AppRole> roleManager) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Create(string name, CancellationToken cancellationToken)
        {
            AppRole appRole = new()
            {
                Name = name,
            };

            IdentityResult result = await roleManager.CreateAsync(appRole);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var roles = await roleManager.Roles.ToListAsync(cancellationToken);
            return Ok(roles);
        }
    }
}
