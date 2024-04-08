using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /*

        /// <summary>
        /// Возвращает список пользователей по имени
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        [Route(template: "by-name")]
        public async Task<IActionResult> GetAllByName([FromQuery] GetUsersByNameRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsersByNameAsync(request, cancellationToken);
            return Ok(result);
        }

        */
    }
}
