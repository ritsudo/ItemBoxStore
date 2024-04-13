using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Infrastructure.PasswordHasher;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Users
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    [ApiController]
    [Route(template: "[controller]")]
    public partial class UserController(
        IUserService userService,
        ILogger<UserController> logger,
        IPasswordHasher passwordHasher) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        private readonly ILogger<UserController> _logger = logger;

        private readonly IPasswordHasher _passwordHasher = passwordHasher;
    }
}
