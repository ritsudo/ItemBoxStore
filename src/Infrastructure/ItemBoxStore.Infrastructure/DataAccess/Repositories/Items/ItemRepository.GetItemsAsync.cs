using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Items;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories.Items
{
    /// <inheritdoc />
    public partial class ItemRepository : IItemRepository
    {

        public async Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllResponseWithPagination<ItemDto>();

            var query = _repository.GetAll();

            var totalCount = await query.CountAsync(cancellationToken);
            result.TotalPages = (totalCount / request.BatchSize) + 1;

            Expression<Func<Item, object>> orderByExpression;
            switch(request.SortMode)
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

            var paginationQuery = await query
                .OrderBy(orderByExpression)
                .Skip(request.BatchSize * (request.PageNumber - 1))
                .Take(request.BatchSize)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);

            result.Result = paginationQuery;

            return result;
        }

    }
}
