using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Contexts.User.Services
{
    /// <summary>
    /// Инициализирует экземпляр StorageFileService
    /// </summary>
    public partial class StorageFileService : IStorageFileService
    {

        /// <inheritdoc/>
        public Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken)
        {
            return _fileRepository.DownloadAsync(id, cancellationToken);
        }
    }
}
