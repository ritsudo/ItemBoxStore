using AutoMapper;
using ItemBoxStore.Application.Repositories;
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
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;

        /// <inheritdoc/>
        public UserRepository(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
