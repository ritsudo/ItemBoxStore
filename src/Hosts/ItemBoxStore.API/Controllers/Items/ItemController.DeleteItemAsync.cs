using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id, CancellationToken cancellationToken)
        {
            await _itemService.DeleteAsync(id, cancellationToken);

            return Ok();
        }
    }
}
