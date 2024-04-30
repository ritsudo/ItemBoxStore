using DNTCaptcha.Core;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
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
        public async Task<IActionResult> Register([FromForm] RegisterUserRequestWithCaptcha model, CancellationToken cancellationToken)
        {
            if (!_validatorService.HasRequestValidCaptchaEntry())
            {
                this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Please enter the security code as a number.");
                return StatusCode((int)HttpStatusCode.Forbidden, "Введите корректный код проверки");
            }

            var passwordHash = _passwordHasher.Hash(model.Password);

                var dto = new RegisterUserRequest
                {
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

        /// <summary>
        /// Получить DNT капчу
        /// </summary>
        /// <returns></returns>
        [HttpGet("register")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = 0)]
        [EnableRateLimiting(DNTCaptchaRateLimiterPolicy.Name)] // don't forget this one!
        public ActionResult<DNTCaptchaApiResponse> CreateDNTCaptchaParams() =>
        // Note: For security reasons, a JavaScript client shouldn't be able to provide these attributes directly.
        // Otherwise an attacker will be able to change them and make them easier!
        _apiProvider.CreateDNTCaptcha(new DNTCaptchaTagHelperHtmlAttributes
        {
            BackColor = "#f7f3f3",
            FontName = "Tahoma",
            FontSize = 18,
            ForeColor = "#111111",
            Language = Language.English,
            DisplayMode = DisplayMode.SumOfTwoNumbers,
            Max = 90,
            Min = 1,
        });
        

    }
}
