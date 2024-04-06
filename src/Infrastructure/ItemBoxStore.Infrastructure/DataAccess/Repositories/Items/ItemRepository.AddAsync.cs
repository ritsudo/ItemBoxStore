using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Domain.Items;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        public async Task AddAsync(Item itemDto, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(itemDto, cancellationToken);
        }

    }
}
