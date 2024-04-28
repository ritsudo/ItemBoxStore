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
            if (id == Guid.Empty)
            {
                var response = new FileDto();
                EmptyFileResponse emptyFileResponse = new EmptyFileResponse();
                response.Content = emptyFileResponse.returnResult();
                response.ContentType = "image/png";
                response.Name = "1.png";

                return File(response.Content, response.ContentType, response.Name);
            }

            var result = await _fileService.DownloadAsync(id, cancellationToken);
            if (result == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            Response.ContentLength = result.Content.Length;
            return File(result.Content, result.ContentType, result.Name);
        }

        /// <summary>
        /// Образец пустого файла TODO вынести в конфиг
        /// </summary>
        /// <returns></returns>
        internal class EmptyFileResponse()
        {
            string EncodedEmptyFile = "iVBORw0KGgoAAAANSUhEUgAAAgAAAAIAAQMAAADOtka5AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAGUExURREBL9na20BS1l8AAAAJcEhZcwAADsMAAA7DAcdvqGQAAATaSURBVHja7dxNjts2FABgajQBU8xC2XWpphfIETSH6L5HkQIE6BF6nBFyghyBRyC6EgpCLBKPRckixcf36KGdPm4G8FgfHvkomj+2hCUWBhhggAEGGGCAAQYYYIABBhhgAA1oIaq/ejRgxKlILDC+AqLBAVospUUB48MCvMMASqyKRADjGqjSASM2pU0G1BaQyYC4KKmAuQTaREBfAjIRGAS8Dt5/7a4XfRKg90CTBKg9UCcB+yY4qIMHmAURmHyATAC0D6gTgNEHiATAe32wEfbA7AdaMDD5AQkGtB+owYC/DYPjGhgQUCDQhsE0wIEOCEwhoKECEgioEFADgVASQnncAcPVgEAed0Dw+kAeL4E5DLQgwFCBKQxIEKDDQE0FKhCgrggIEDAeAD0EGA6ArjjQQoCD6/1jUm5gPgIkFagBgCkOTEdARQUEANC5gU+bu6tPBupts6YD32+fiQJ8f+nfrRcBtgPSqe+6VmjjwHZAOt093/DAqc4GD9gLoEkEzl132LYJHKipwPn9Cgs0VODc6OayTgfAZlTvEMDXNbB0/cu0QCOwRKDavYoGxl1MIMA1mYIDDytAYoDBC0xwYJ2EJh9gnuHAqg5u+DC4Nmj3gfVJVegwwPtjoKNGEAeqFbCKd0RFgAKGK0WgwMDjbw6wGGAdAQoY/ICmRgAHPvuB6e2qMLw/jKDFRgCvwpcrtQEcGJ+pwGpQRALeCAw1CyZXBG8AfP3ggP4+qxBY4MABVXkBeEdSz0RAi+LAh4wR2D0Qnx9Mx1VAAxoMmIFYBeNvA71/KQQ8EoHVJsx6bq/AgM0I1DjALd/Xa7wRDtg//v7x55/f/0QC3kIGhuKAJ7NlgBoLzFTA3AwgscBEBc7jSYMFVC6gxQIjFRiKA+dRrkMCMxVYPq56JDBRgWXSYJGAogLjwYgGAgYisGSxRgKGCixZfEICSxYlEliy2CCBgQqIo3sJALh5V4sDliRUPQ5w828koKjAkoRfkMASAOzcOT/g5u/vcIBbgtQ4wGWxwQGKCixZrDocII7vpSjgbqXHFyIQeGcMcFl8wAEuix9xgH8J9JaA21T5FQcMkY4YBVwWX1DAHOuICUCPAkysI8YA1xErHKDzARIHqHzAJxwwxrrB1YEh1o/AQPCr55EIRDZA4oA5H9AWB/pCgIlm8drAFM3imwEtFeiogC0N1MWBphigo1kERkAGXqiAJQJVcUAWB9riQFcc6IsDFg2YPEBNBariEZCBJyogqUDDwA0AHRVoi0fAQAagxwPTzwLY/zWgbyOC6v4BboN7ByYGGLgdoCYAhgr82JCUJKCKPZYmtjUeeaRM/JjIMsDAbQAvRAD9gKXXYmLDAeSsraMAQ2zhCjlnIo+JNzDZJqzaFHXxfTotJOwfCCLwetCF38kymQD8bt5EBQ6+sg8Dzufe6E3ZkQqcT507KtAWAwQRmLMBDRWQpQBTHJiyAfXdApoBBn4yoGKAAb4X7hzI99lYbH5gbgcgzxPLA8Vm6/lWLGSg3Krt4FfKMOB14Ule+pIB/PIf8K0y0P4BHpjj9xJoE4awDTRGezJoI8riAfIRCfmEw0aTANnRJG2JqlgbxgAdfXJ/xJ/DP52AAVY9WRoQLQwwwAADDDDAAAMMMMAAAwwwwAADDFwdsPY/Tm8CChdKEMkAAAAASUVORK5CYII=";
            public byte[] returnResult()
            {
                return Convert.FromBase64String(EncodedEmptyFile);
            }
        }
    }
}
