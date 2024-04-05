using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
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
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _fileRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
