using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Users
{
    public partial class StorageFileController : ControllerBase
    {
        /// <summary>
        /// Получение информации о файле по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}/info")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetInfoById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _fileService.GetInfoByIdAsync(id, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        private static async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }

    }
}
