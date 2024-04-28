using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Возвращает список объявлений пользователя по Id 
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список объявлений</returns>
        [HttpGet]
        [Route(template: "by-user-id/{id:Guid}")]
        public async Task<IActionResult> GetAllItemsByUserId(Guid id, CancellationToken cancellationToken)
        {
            var result = await _itemService.GetItemsByUserIdAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}
