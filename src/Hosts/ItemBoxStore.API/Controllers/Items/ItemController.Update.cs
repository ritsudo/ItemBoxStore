using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Create([FromRoute] Guid id, UpdateItem.UpdateItemRequest updateRequest, CancellationToken cancellationToken)
        {
            var result = await _itemService.UpdateAsync(new UpdateItem.UpdateItemRequest
            {
                Id = id,
                Name = updateRequest.Name,
                SubCategoryId = updateRequest.SubCategoryId,
                Description = updateRequest.Description,
                Price = updateRequest.Price
            }, cancellationToken);
            return Ok(result);
        }
        
    }
}
