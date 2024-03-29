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
        public async Task<Guid> AddAsync(UserDto model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();
            await _userRepository.AddAsync(model, cancellationToken);

            return model.Id;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(UserDto model, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateAsync(model, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public ValueTask<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
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
