using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Contracts.Users;

namespace ItemBoxStore.Application.Contexts.User.Services.Definitions
{
    /// <summary>
    /// Сервис для работы с файлами
    /// </summary>
    public interface IStorageFileService
    {
        /// <summary>
        /// Создание файла
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Guid> UploadAsync(FileDto model, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получение данных о файле
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Информация о файле</returns>
        Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получение файла
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Информаци о скачиваемом файле.</returns>
        Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken);

    }
}
