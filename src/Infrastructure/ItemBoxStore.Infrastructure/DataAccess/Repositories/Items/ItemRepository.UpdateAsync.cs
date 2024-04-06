using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        public async Task UpdateAsync(ItemDto itemDto, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(itemDto.Id, cancellationToken);
            await _repository.UpdateAsync(item, cancellationToken);
        }

    }
}
