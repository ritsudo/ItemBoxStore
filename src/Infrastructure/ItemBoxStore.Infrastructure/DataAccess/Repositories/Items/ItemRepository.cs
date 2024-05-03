using AutoMapper;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.Repository;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    /// <inheritdoc/>
    public partial class ItemRepository(IRepository<Item> repository, IReadOnlyRepository<Item> readOnlyRepository, IMapper mapper) : IItemRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Item> _repository = repository;
        private readonly IReadOnlyRepository<Item> _readOnlyRepository = readOnlyRepository;
    }
}
