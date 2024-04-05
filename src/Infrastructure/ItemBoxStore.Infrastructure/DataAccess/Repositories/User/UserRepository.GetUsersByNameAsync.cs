using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetUsersByNameAsync(GetUsersByNameRequest request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAll()
                .Where(user => user.Login.Equals(request.Name));

            if (request.IsEmailConfirmed)
            {
                query = query.Where(user => user.EmailConfirmed == request.IsEmailConfirmed);
            }
                
            return await query
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

    }
}
