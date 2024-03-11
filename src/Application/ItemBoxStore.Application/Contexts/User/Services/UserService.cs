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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CreateUserDto model, CancellationToken cancellationToken)
        {
            return _userRepository.CreateAsync(model, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _userRepository.GetByIdAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return _userRepository.GetUsersAsync(cancellationToken);
        }
    }
}
