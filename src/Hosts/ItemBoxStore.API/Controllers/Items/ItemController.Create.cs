using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateItem.Request request, CancellationToken cancellationToken)
        {
            var result = await _itemService.CreateAsync(request, cancellationToken);
            return Created(nameof(result), result);
        }
    }
}
