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
    public partial class StorageFileRepository : IStorageFileRepository
    {
        private readonly IMapper _mapper;
        private readonly IRepository<StorageFile> _repository;

        public StorageFileRepository(IMapper mapper, IRepository<StorageFile> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
