using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemBoxStore.Domain.Users;

namespace ItemBoxStore.Application.Contexts.User
{
    internal interface IUserService
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreateUserDto model, CancellationToken cancellationToken);
    }
}
