using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Images;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Repositories
{
    /// <summary>
    /// Репозиторий для работы с файлами
    /// </summary>
    public interface IStorageFileRepository
    {
        /// <summary>
        /// Получение информации о файле по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Информация о файле</returns>
        Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление файла по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Загрузка файла в систему
        /// </summary>
        /// <param name="file">Сущность файла</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Идентификатор загруженного файла.</returns>
        Task<Guid> UploadAsync(StorageFile file, CancellationToken cancellationToken);

        /// <summary>
        /// Скачивание файла.
        /// </summary>
        /// <param name="id">Идентификатор файла</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Информаци о скачиваемом файле</returns>
        Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken);
    }
}
