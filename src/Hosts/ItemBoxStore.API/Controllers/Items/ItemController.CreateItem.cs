using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using static ItemBoxStore.Contracts.Items.CreateItemRequest;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Создать новое объявление
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Authorize]//(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(ItemDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateItem(Contracts.Items.CreateItemRequest model, CancellationToken cancellationToken)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            if (token == null)
            {
                _logger.LogInformation("Ошибка создания объявления: токен отсутствует");
                return Unauthorized();
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                if (userId == null)
                {
                    _logger.LogInformation("Ошибка создания объявления: не удалось найти пользователя");
                    return Unauthorized();
                }

                var dto = new ItemDtoDetailed
                {
                    Name = model.Name,
                    SubCategoryId = model.SubCategoryId,
                    Description = model.Description,
                    Location = model.Location,
                    Price = model.Price,
                    AuthorId = new Guid(userId)
                };

                var result = await _itemService.AddAsync(dto, cancellationToken);
                return CreatedAtAction(nameof(CreateItem), new { result });

            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка сервера при работе с объявлением");
                return StatusCode(500);
            }
        }
    }
}
