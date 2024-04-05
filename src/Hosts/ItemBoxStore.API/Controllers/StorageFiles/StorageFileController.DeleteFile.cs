using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class StorageFileController : ControllerBase
    {
        /// <summary>
        /// Удалить файл по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _fileService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
