using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Contexts.Item.Services.Implementations
{
    /// <summary>
    /// Инициализирует сервис ItemService
    /// </summary>
    public partial class ItemService : IItemService
    {
        public async Task<Guid> AddAsync(ItemDtoDetailed model, CancellationToken cancellationToken)
        {
            var entity = new Domain.Items.Item { 
                Id = new Guid(),
                Name = model.Name,
                Description = model.Description,
                Location = model.Location,
                Price = model.Price,
                AuthorId = model.AuthorId,
                SubCategoryId = model.SubCategoryId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _itemRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }

    }
}
