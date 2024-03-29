﻿using ItemBoxStore.Contracts.Users;
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
        public Task<IEnumerable<UserDto>> GetUsersAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public ValueTask<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddAsync(UserDto userDto, CancellationToken cancellationToken);
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
