using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static ItemBoxStore.Contracts.Items.CreateItem;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Создать новое объявление
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ItemDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateItem(CreateItemRequest model, CancellationToken cancellationToken)
        {
            var dto = new ItemDto
            {
                Name = model.Name,
                SubCategoryId = model.SubCategoryId,
                Description = model.Description,
                Price = model.Price
            };

            var result = await _itemService.AddAsync(model, cancellationToken);
            return CreatedAtAction(nameof(CreateItem), new { result });
        }
    }
}
