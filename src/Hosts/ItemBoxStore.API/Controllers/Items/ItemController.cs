using ItemBoxStore.API.Controllers.Users;
using ItemBoxStore.Application.Contexts.Item.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    /// <summary>
    /// Контроллер для работы с объвлениями
    /// </summary>
    [ApiController]
    [Route(template: "[controller]")]
    public partial class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

    }
}
