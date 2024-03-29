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
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;

        /// <inheritdoc/>
        public UserRepository(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public ValueTask<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = _repository.GetByIdAsync(id, cancellationToken).Result;

            var result = new UserDto()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Phone = user.Phone,
            };

            return new ValueTask<UserDto>(result);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken)
        {
            var userList = await _repository.GetAll().ToListAsync(cancellationToken);

            return userList.Select(u => new UserDto
            {
                Id = u.Id,
                Login = u.Login,
                Email = u.Email,
                Name = u.Name,
                Phone = u.Phone
            });
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = _repository.GetByIdAsync(userDto.Id, cancellationToken).Result;
            await _repository.UpdateAsync(user, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task AddAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = userDto.Id,
                Login = userDto.Login,
                Email = userDto.Email,
                Name = userDto.Name,
                Phone = userDto.Phone,
            };

            await _repository.AddAsync(user, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }
    }
}
