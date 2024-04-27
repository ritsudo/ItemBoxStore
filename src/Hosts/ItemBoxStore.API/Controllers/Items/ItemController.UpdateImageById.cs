using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.StorageFiles;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace ItemBoxStore.API.Controllers.Items
{
    public partial class ItemController : ControllerBase
    {
        /// <summary>
        /// Обновить картинку объявления по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file">Входящий файл</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("image-change/{id:Guid}")]
        public async Task<IActionResult> UpdateImageById(Guid id, IFormFile file, CancellationToken cancellationToken)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            if (token == null)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, "Не авторизирован для операции");
            }

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;

                if (userId == null)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, "Нет такого пользователя");
                }

                var userGuid = new Guid(userId);

                var item = await _itemService.GetByIdAsync(id, cancellationToken);

                if (item == null)
                {
                    _logger.LogInformation("Нет такого объявления");
                    return StatusCode((int)HttpStatusCode.NotFound, "Нет такого объявления");
                }

                if (item.AuthorId != userGuid)
                {
                    _logger.LogInformation("Попытка изменить не своё объявление пользователем {UserId}", userId);
                    return StatusCode((int)HttpStatusCode.Forbidden, "Нет прав изменять это объявление");
                }

                // File service part //

                var bytes = await GetBytesAsync(file, cancellationToken);

                var fileDto = new FileDto
                {
                    Name = file.FileName,
                    Content = bytes,
                    ContentType = file.ContentType,
                };

                var resultFileGuid = await _fileService.UploadAsync(fileDto, cancellationToken);

                if (resultFileGuid == null || resultFileGuid == Guid.Empty)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Ошибка на этапе загрузки файла");
                }

                ModifyImageRequest request = new ModifyImageRequest
                {
                    ItemId = item.Id,
                    ImageId = resultFileGuid
                };

                await _itemService.ModifyImage(request, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка сервера при изменении объявления");
                return StatusCode((int)HttpStatusCode.InternalServerError, "Ошибка сервера при изменении объявления");
            }

        }

        private static async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }

    }
}
