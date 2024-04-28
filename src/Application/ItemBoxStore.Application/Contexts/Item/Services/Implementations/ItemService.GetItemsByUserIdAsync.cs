using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
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
        public async Task<IEnumerable<ItemDto>> GetItemsByUserIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var specification = new ItemByUserIdSpecification(id);
            return await _itemRepository.GetItemsBySpecificationAsync(specification, cancellationToken);
        }

    }
}
