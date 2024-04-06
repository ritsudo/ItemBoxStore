using AutoMapper;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Infrastructure.Repository;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Item> _repository;

        /// <inheritdoc/>
        public ItemRepository(IRepository<Item> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
