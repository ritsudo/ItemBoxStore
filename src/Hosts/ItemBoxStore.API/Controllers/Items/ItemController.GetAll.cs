using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(template: "all")]
        public async Task<IActionResult> GetAll(GetPaged.GetPagedRequest request, CancellationToken cancellationToken)
        {
            var result = await _itemService.GetAll(request, cancellationToken);
            return Ok(result);
        }
    }
}
