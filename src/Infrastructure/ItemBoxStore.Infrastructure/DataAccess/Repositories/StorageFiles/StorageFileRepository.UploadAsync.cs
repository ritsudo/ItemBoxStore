using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Images;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для файлов
    /// </summary>
    public partial class StorageFileRepository : IStorageFileRepository
    {
        /// <inheritdoc/>
        public async Task<Guid> UploadAsync(StorageFile file, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(file, cancellationToken);
            return file.Id;
        }

    }
}
