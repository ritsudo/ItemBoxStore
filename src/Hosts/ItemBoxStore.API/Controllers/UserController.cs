using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    [ApiController]
    [Route(template:"[controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        [Route(template:"all")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok();
        } 

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _userService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto model, CancellationToken cancellationToken)
        {
            var userId = await _userService.CreateAsync(model, cancellationToken);
            return Created(nameof(CreateAsync), userId);
        }
    }
}
