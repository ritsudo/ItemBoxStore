using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using static ItemBoxStore.Contracts.Items.CreateItemRequest;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Заменить картинку объявления
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("image-change")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddImageToItem(ModifyImageRequest model, CancellationToken cancellationToken)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            if (token == null)
            {
                return Unauthorized();
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                if (userId == null)
                {
                    return Unauthorized();
                }

                var userGuid = new Guid(userId);

                var item = await _itemService.GetByIdAsync(model.ItemId, cancellationToken);

                if (item == null)
                {
                    _logger.LogInformation("Нет такого объявления");
                    return NotFound();
                }

                if (item.AuthorId != userGuid)
                {
                    _logger.LogInformation("Попытка изменить не своё объявление пользователем {UserId}", userId);
                    return Forbid();
                }

                // TODO проверка существует ли файл

                await _itemService.ModifyImage(model, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка сервера при изменении объявления");
                return StatusCode(500);
            }
        }
    }
}
