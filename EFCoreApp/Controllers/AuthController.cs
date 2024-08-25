using EFCoreApp.Domain.Dtos.Auth;
using EFCoreApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;


namespace EFCoreApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public sealed class AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {
            AppUser appUser = new AppUser()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
            };

            IdentityResult result = await userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.FindByIdAsync(request.Id.ToString());
            if (appUser is null)
            {
                return BadRequest(new
                {
                    Message = "User not found"
                });
            }
            IdentityResult result = await userManager.ChangePasswordAsync(appUser, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.FindByEmailAsync(email);

            if (appUser is null)
            {
                return BadRequest(new
                {
                    Message = "User not found"
                });
            }

            string token = await userManager.GeneratePasswordResetTokenAsync(appUser);

            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordUsingToken(ChangePasswordUsingToken request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.FindByEmailAsync(request.Email);

            if (appUser is null)
            {
                return BadRequest(new
                {
                    Message = "User not found"
                });
            }

            IdentityResult result = await userManager.ChangePasswordAsync(appUser, request.Token, request.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(x => x.Email == request.UserNameOrEmail || x.UserName == request.UserNameOrEmail, cancellationToken);



            if (appUser is null)
            {
                return BadRequest(new
                {
                    Message = "user not found"
                });
            }

            bool result = await userManager.CheckPasswordAsync(appUser, request.Password);

            if (!result)
            {
                return BadRequest(new
                {
                    Message = "Password is incorrect"
                });
            }
            return Ok(new
            {
                Token = "token"
            });
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithSignInManager(LoginDto request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(x => x.Email == request.UserNameOrEmail || x.UserName == request.UserNameOrEmail, cancellationToken);



            if (appUser is null)
            {
                return BadRequest(new
                {
                    Message = "user not found"
                });
            }

            SignInResult result = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, true);

            if (result.IsLockedOut)
            {
                TimeSpan? timeSpan = appUser.LockoutEnd - DateTime.UtcNow;

                if (timeSpan is not null)
                {
                    return StatusCode(500, $"Login fail 3 time . User locked {timeSpan.Value} second");
                }
                else
                {
                    return StatusCode(500, $"Login fail 3 time . User locked 30 second");
                }
            }

            if (result.IsNotAllowed)
            {
                return StatusCode(500, "Mail is not approved");
            }
            if (!result.Succeeded)
            {
                return StatusCode(500, "Password is incorrect");
            }

            return Ok(new
            {
                Token = "token"
            });
        }
    }
}
