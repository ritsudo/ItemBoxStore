using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Expression<Func<ItemBoxStore.Domain.Items.Item, object>> orderByExpression;

            switch (request.SortMode)
            {
                case 0:
                    orderByExpression = item => item.Id;
                    break;

                case 1:
                    orderByExpression = item => item.Name;
                    break;

                case 2:
                    orderByExpression = item => item.Price;
                    break;

                default:
                    orderByExpression = item => item.Id;
                    break;
            }

            return await _itemRepository.GetItemsAsync(request, orderByExpression, cancellationToken);
        }
    }
}
