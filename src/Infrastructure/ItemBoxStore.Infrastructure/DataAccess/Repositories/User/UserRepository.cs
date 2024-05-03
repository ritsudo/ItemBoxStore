using AutoMapper;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.Repository;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    /// <inheritdoc/>
    public partial class UserRepository(IRepository<User> repository, IReadOnlyRepository<User> readOnlyRepository, IMapper mapper) : IUserRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IReadOnlyRepository<User> _readOnlyRepository = readOnlyRepository;
        private readonly IRepository<User> _repository = repository;
    }
}
