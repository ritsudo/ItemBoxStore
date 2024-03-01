using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _userService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto model, CancellationToken)
        {
            var userId = await _userService.CreateAsync(model, cancellationToken);
            return Created(nameof(CreateAsync), userId);
        }
    }
}
