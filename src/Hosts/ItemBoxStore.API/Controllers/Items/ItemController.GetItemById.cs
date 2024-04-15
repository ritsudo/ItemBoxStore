using ItemBoxStore.Contracts.Items;
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
            //Type: ItemDto
            var result = await _itemService.GetByIdAsync(id, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync(result.AuthorId, cancellationToken);

            //Если создатель объявления уже был удалён, то и объявление не будет отображаться
            if (user == null)
            {
                return NotFound();
            }

            result.AuthorName = user.Name;

            return Ok(result);
        }
    }
}
