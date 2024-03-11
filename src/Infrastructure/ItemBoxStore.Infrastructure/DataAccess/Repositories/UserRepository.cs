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
        List<UserDto> UserList = new List<UserDto> {
            new UserDto { 
                Id = Guid.NewGuid(),
                Name = "User 1"
            },
            new UserDto { 
                Id = Guid.NewGuid(),
                Name = "User 2"}
        };

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CreateUserDto userDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => UserList.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name
            }));
        }
    }
}
