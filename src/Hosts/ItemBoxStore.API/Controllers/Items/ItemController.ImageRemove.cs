using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static ItemBoxStore.Contracts.Items.CreateItemRequest;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Удалить картинку из коллекции изображений объявления
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("image-remove")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ImageRemove(ModifyImageRequest model, CancellationToken cancellationToken)
        {
            return NoContent();
        }
    }
}
