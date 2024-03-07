using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<IReadOnlyCollection<UserDto>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
