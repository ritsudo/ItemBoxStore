using AutoMapper;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.Repository;

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
