using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Register(RegisterUserRequest model, CancellationToken cancellationToken)
        {
            var passwordHash = _passwordHasher.Hash(model.Password);

            var dto = new RegisterUserRequest {
                Email = model.Email,
                Login = model.Login,
                Name = model.Name,
                Phone = model.Phone,
                Password = passwordHash
            };

            var userRequest = new GetUsersByLoginRequest
            {
                Login = model.Login
            };

            var user = await _userService.GetByLoginAsync(userRequest, cancellationToken);

            if (user != null)
            {
                //Пользователь уже существует
                return StatusCode((int)HttpStatusCode.Forbidden, "Пользователь с данным логином уже существует");
            }

            var result = await _userService.AddAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(Register), new { result });
        }
    }
}
