using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _userService.DeleteAsync(id, cancellationToken);
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }
    }
}