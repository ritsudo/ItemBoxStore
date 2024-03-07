using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemBoxStore.Contracts.Users;

namespace ItemBoxStore.Application.Contexts.User.Services
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreateUserDto model, CancellationToken cancellationToken);
    }
}
