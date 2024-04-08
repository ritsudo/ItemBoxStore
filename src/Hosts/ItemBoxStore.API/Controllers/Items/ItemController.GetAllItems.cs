using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Возвращает список всех объявлений с пагинацией
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(template: "all")]
        [ProducesResponseType(typeof(GetAllResponseWithPagination<ItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllItems([FromQuery] GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemsAsync(request, cancellationToken);
            return Ok(result);
        }
    }
}
