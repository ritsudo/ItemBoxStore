using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.StorageFiles;
using ItemBoxStore.Contracts.Users;
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
        public Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                              .ProjectTo<FileInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

    }
}
