using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Domain.Users;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task AddAsync(User userDto, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(userDto, cancellationToken);
        }
    }
}
