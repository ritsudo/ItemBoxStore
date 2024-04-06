using ItemBoxStore.Application.Repositories;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }

    }
}
