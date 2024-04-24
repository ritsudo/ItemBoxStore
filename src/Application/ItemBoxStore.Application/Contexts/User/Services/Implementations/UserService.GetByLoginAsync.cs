using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
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
        public async ValueTask<UserDto> GetByLoginAsync(GetUsersByLoginRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersByLoginAsync(request, cancellationToken);
        }
    }
}
