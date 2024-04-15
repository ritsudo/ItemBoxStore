﻿using ItemBoxStore.Contracts.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(Guid id, CancellationToken cancellationToken)
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

                var item = await _itemService.GetByIdAsync(id, cancellationToken);

                if (item.AuthorId != userGuid)
                {
                    return Forbid();
                }

                await _itemService.DeleteAsync(id, cancellationToken);
                return Ok();

            }
            catch (Exception ex)
            {
                return Unauthorized();
            }



        }
    }
}
