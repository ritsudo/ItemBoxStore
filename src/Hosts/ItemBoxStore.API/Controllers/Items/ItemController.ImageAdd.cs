using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static ItemBoxStore.Contracts.Items.CreateItemRequest;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Добавить картинку в коллекцию изображений объявления
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("image-add")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddImageToItem(ModifyImageRequest model, CancellationToken cancellationToken)
        {
            return NoContent();
        }
    }
}
