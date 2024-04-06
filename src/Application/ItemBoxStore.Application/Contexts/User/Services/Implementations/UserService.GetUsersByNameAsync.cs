using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
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
        public async Task<IEnumerable<UserDto>> GetUsersByNameAsync(GetUsersByNameRequest request, CancellationToken cancellationToken)
        {
            var specification = new UserByNameSpecification(request.Name);
            return await _userRepository.GetUsersBySpecificationAsync(specification, cancellationToken);
        }
    }
}
