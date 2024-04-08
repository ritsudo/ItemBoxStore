using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(RegisterUserRequest model, CancellationToken cancellationToken)
        {
            var dto = new UserDto {
                Email = model.Email,
                Login = model.Login,
                Name = model.Name,
                Phone = model.Phone
            };

            var result = await _userService.AddAsync(model, cancellationToken);
            return CreatedAtAction(nameof(Register), new { result });
        }
    }
}
