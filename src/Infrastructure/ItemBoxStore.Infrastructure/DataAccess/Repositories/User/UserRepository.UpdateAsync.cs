using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = await _readOnlyRepository.GetByIdAsync(userDto.Id, cancellationToken);
            await _repository.UpdateAsync(user, cancellationToken);
        }

    }
}
