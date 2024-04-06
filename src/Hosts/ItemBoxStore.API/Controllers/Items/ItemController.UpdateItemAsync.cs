using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateItemAsync(ItemDto model, CancellationToken cancellationToken)
        {
            await _itemService.UpdateAsync(model, cancellationToken);
            return await Task.Run(() => Ok(new ItemDto()), cancellationToken);
        }

    }
}
