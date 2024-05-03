using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyRepository.GetByIdAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}
