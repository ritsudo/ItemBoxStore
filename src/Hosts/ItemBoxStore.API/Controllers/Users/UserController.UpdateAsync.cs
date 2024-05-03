using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Обновить данные пользователя по Id
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync(UserDto model, CancellationToken cancellationToken)
        {
            await _userService.UpdateAsync(model, cancellationToken);
            return await Task.Run(() => Ok(new UserDto()), cancellationToken);
        }
    }
}
