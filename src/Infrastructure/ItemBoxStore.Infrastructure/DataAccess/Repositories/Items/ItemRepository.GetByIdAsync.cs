using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;
using Microsoft.EntityFrameworkCore;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {

        public async Task<ItemDtoDetailed> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().Where(s => s.Id == id)
            .ProjectTo<ItemDtoDetailed>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        }

    }
}
