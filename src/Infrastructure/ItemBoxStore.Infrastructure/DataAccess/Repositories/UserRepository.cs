using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public Task<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
