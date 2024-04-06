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
        public async Task UpdateAsync(ItemDto model, CancellationToken cancellationToken)
        {
            await _itemRepository.UpdateAsync(model, cancellationToken);
        }
    }
}
