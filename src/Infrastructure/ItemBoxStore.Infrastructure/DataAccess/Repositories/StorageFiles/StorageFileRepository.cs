using AutoMapper;
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
    public partial class StorageFileRepository(IMapper mapper, IReadOnlyRepository<StorageFile> readOnlyRepository, IRepository<StorageFile> repository) : IStorageFileRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IReadOnlyRepository<StorageFile> _readOnlyRepository = readOnlyRepository;
        private readonly IRepository<StorageFile> _repository = repository;
    }
}
