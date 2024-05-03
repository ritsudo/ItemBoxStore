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

        public async Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, Expression<Func<Item, object>> orderByExpression, CancellationToken cancellationToken)
        {
            var result = new GetAllResponseWithPagination<ItemDto>();

            var query = _readOnlyRepository.GetAll();

            var totalCount = await query.CountAsync(cancellationToken);
            result.TotalPages = (totalCount / request.BatchSize) + 1;

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
