﻿using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetUsersBySpecificationAsync(Specification<User> request, CancellationToken cancellationToken)
        {
            return await _readOnlyRepository.GetAll()
                .Where(request.ToExpression())
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }

    }
}
