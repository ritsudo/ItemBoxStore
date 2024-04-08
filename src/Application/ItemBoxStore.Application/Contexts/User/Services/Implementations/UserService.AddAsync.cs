using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Contexts.User.Services
{
    /// <summary>
    /// Инициализирует экземпляр UserService
    /// </summary>
    public partial class UserService : IUserService
    {
        /// <inheritdoc/>
        public async Task<Guid> AddAsync(RegisterUserRequest model, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ItemBoxStore.Domain.Users.User>(model);

            await _userRepository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
