using AutoMapper.QueryableExtensions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using Microsoft.EntityFrameworkCore;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetUsersByNameAsync(GetUsersByNameRequest request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.GetAll()
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
