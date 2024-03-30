using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public partial class UserRepository : IUserRepository
    {
        /// <inheritdoc/>
        public async Task UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(userDto.Id, cancellationToken);
            await _repository.UpdateAsync(user, cancellationToken);
        }

    }
}
