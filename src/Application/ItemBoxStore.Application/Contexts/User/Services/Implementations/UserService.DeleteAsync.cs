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
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {

                await _userRepository.DeleteAsync(id, cancellationToken);
            }
            catch {
                throw new ArgumentNullException(nameof(id));
            }
        }
    }
}
