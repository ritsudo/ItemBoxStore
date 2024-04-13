using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Выйти пользователю
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("logout")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
                );

            return NoContent();
        }
    }
}
