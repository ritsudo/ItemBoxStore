﻿using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using Microsoft.EntityFrameworkCore;

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

            var paginationQuery = await query
                .OrderBy(item => item.Id)
                .Skip(request.BatchSize * (request.PageNumber - 1))
                .Take(request.BatchSize)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);

            result.Result = paginationQuery;

            return result;
        }

    }
}