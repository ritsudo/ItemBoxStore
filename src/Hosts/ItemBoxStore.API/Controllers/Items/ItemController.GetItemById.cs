using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Вернуть объявление по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetItemById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _itemService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}
