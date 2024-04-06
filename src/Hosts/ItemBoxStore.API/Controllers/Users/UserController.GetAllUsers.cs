using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <param name="request">Запрос на получение пользователей с пагинацией</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        [Route(template: "all")]
        [ProducesResponseType(typeof(GetAllResponseWithPagination<UserDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsersAsync(request, cancellationToken);
            return Ok(result);
        }
    }
}
