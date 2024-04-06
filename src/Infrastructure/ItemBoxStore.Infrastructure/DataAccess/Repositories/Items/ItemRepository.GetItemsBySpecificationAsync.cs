using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Items;
using Microsoft.EntityFrameworkCore;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        public async Task<IEnumerable<ItemDto>> GetItemsBySpecificationAsync(Specification<Item> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll()
                .Where(request.ToExpession())
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }

    }
}
