using ItemBoxStore.API.Controllers.Users;
using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    /// <summary>
    /// Контроллер для работы с объвлениями
    /// </summary>
    [ApiController]
    [Route(template: "[controller]")]
    public partial class ItemController(
        IItemService itemService,
        IUserService userService,
        ILogger<ItemController> logger) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IItemService _itemService = itemService;
        private readonly ILogger<ItemController> _logger = logger;
    }
}
