using ItemBoxStore.Application.Repositories;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyRepository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _repository.DeleteAsync(entity, cancellationToken);
        }

    }
}
