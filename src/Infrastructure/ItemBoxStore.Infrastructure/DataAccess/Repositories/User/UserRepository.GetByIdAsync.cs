using AutoMapper.QueryableExtensions;
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
        public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
