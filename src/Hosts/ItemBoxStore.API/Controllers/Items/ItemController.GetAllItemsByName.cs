using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Возвращает список объявлений по названию
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список объявлений</returns>
        [HttpGet]
        [Route(template: "by-name")]
        public async Task<IActionResult> GetAllItemsByName([FromQuery] GetItemsByNameRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemsByNameAsync(request, cancellationToken);
            return Ok(result);
        }
    }
}
