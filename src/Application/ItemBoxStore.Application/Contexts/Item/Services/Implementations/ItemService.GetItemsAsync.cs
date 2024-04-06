using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
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

        public async Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetItemsAsync(request, cancellationToken);
        }
    }
}
