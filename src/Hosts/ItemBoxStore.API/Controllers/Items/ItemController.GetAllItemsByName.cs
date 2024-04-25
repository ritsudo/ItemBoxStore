using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
            if (request.Name == null || request.Name == "")
            {
                var allRequest = new GetAllItemsRequest();
                var allResult = await _itemService.GetItemsAsync(allRequest, cancellationToken);
                return Ok(allResult.Result);
            }
            var result = await _itemService.GetItemsByNameAsync(request, cancellationToken);
            return Ok(result);
        }
    }
}
