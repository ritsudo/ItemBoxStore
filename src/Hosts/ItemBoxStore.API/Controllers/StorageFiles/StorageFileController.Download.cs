using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class StorageFileController : ControllerBase
    {
        /// <summary>
        /// Получить файл по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Список пользователей</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Download(Guid id, CancellationToken cancellationToken)
        {
            var result = await _fileService.DownloadAsync(id, cancellationToken);
            if (result == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            Response.ContentLength = result.Content.Length;
            return File(result.Content, result.ContentType, result.Name);
        }
    }
}
