using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Получить список пользователей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetAllResponseWithPagination<UserDto>> GetUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список пользователей по имени
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<UserDto>> GetUsersByNameAsync(GetUsersByNameRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddAsync(User userDto, CancellationToken cancellationToken);
        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public Task UpdateAsync(UserDto userDto, CancellationToken cancellationToken);
        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
