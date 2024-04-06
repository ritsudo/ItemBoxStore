using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {

        public async Task<IEnumerable<ItemDto>> GetItemsByNameAsync(GetItemsByNameRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll()
                .Where(item => item.Name.Equals(request.Name));

            return await query
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

}

