using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Infrastructure.PasswordHasher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ItemBoxStore.API.Controllers.Tokens
{
    /// <summary>
    /// Контроллер для токенов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController(IConfiguration configuration,
        IUserService userService,
        IPasswordHasher passwordHasher) : ControllerBase
    {
        private IConfiguration _configuration = configuration;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Проверить креды и получить токен пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetUserToken(LoginUserRequest model, CancellationToken cancellationToken)
        {

            var userRequest = new GetUsersByLoginRequest
            {
                Login = model.Login
            };

            var user = await _userService.GetByLoginAsync(userRequest, cancellationToken);

            if (user == null)
            {
                return NotFound();
            }

            var result = _passwordHasher.Verify(user.PasswordHash, model.Password);

            if (!result)
            {
                return StatusCode(403);
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim("UserId", user.Id.ToString()),
                new Claim("UserName", user.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
                );

            return Ok(new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
    }

    /// <summary>
    /// Класс сущности токена
    /// </summary>
    public class TokenDto
    {
        /// <summary>
        /// Выдаваемый токен
        /// </summary>
        public string Token { get; set; }
    }
}
