﻿using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task<GetAllResponseWithPagination<UserDto>> GetUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllResponseWithPagination<UserDto>();

            var query = _readOnlyRepository.GetAll();

            var totalCount = await query.CountAsync(cancellationToken);
            result.TotalPages = (totalCount / request.BatchSize) + 1;

            var paginationQuery = await query
                .OrderBy(user => user.Id)
                .Skip(request.BatchSize * (request.PageNumber - 1))
                .Take(request.BatchSize)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);

            result.Result = paginationQuery;

            return result;
        }

    }
}
