using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Images;
using ItemBoxStore.Domain.Users;
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
        public Task<Guid> UploadAsync(FileDto model, CancellationToken cancellationToken)
        {
            var file = _mapper.Map<StorageFile>(model);
            return _fileRepository.UploadAsync(file, cancellationToken);
        }
    }
}
