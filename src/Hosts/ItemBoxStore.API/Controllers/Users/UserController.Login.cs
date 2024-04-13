using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Войти пользователю
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(LoginUserRequest model, CancellationToken cancellationToken)
        {

            var userGuid = new Guid(model.UserId);

            //TODO get user and hash by login from repo
            var user = await _userService.GetByIdAsync(userGuid, cancellationToken);

            if (user == null)
            {
                return NotFound();
            }

            var result = _passwordHasher.Verify(user.PasswordHash, model.Password);

            if (!result)
            {
                return StatusCode(403);
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, "User"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim("UserId", model.UserId));
            claims.Add(new Claim("UserName", user.Login));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
                );

            return await Task.Run(() => Ok(result), cancellationToken);
        }
    }
}
