using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Contracts.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ItemBoxStore.API.Controllers.Users
{
    /// <summary>
    /// Контроллер для работы с файлами
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public partial class StorageFileController(IStorageFileService fileService, ILogger<StorageFileController> logger) : ControllerBase
    {
        private readonly IStorageFileService _fileService = fileService;

        private readonly ILogger<StorageFileController> _logger = logger;
    }
}
