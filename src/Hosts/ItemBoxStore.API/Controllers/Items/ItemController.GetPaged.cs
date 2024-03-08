using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Получить объявления по страницам
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(template: "paged")]
        public async Task<IActionResult> GetPaged(GetPaged.GetPagedRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemService.GetPaged(request, cancellationToken);
            return Ok(result);
        }
    }
}
