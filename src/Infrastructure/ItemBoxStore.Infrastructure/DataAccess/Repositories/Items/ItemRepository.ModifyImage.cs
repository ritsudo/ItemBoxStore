using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {
        public async Task ModifyImage(ModifyImageRequest model, CancellationToken cancellationToken)
        {
            var item = await _readOnlyRepository.GetByIdAsync(model.ItemId, cancellationToken);
            item.MainImageId = model.ImageId;
            await _repository.UpdateAsync(item, cancellationToken);
        }

    }
}
