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
        /// Создать новый файл
        /// </summary>
        /// <param name="file">Входящий файл</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            var bytes = await GetBytesAsync(file, cancellationToken);

            var fileDto = new FileDto
            {
                Name = file.FileName,
                Content = bytes,
                ContentType = file.ContentType,
            };

            var result = await _fileService.UploadAsync(fileDto, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created, result);
        }

    }
}
