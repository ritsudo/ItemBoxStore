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
        public async Task<UserDto> GetUsersByLoginAsync(GetUsersByLoginRequest request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.GetAll()
                .Where(user => user.Login.Equals(request.Login));

            return await query
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
