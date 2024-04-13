using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Получить информацию о текущем пользователе
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("user-info")]
        public async Task<object> GetUserInfo(CancellationToken cancellationToken)
        {
            var result = new
            {
                Scheme = HttpContext.User.Identity.AuthenticationType,
                IsAuthenticated = HttpContext.User.Identity.IsAuthenticated,
                Claims = HttpContext.User.Claims
                .Select(claim => new
                {
                    claim.Type,
                    claim.Value
                }).ToList()
            };

            return result;
        }
    }
}
