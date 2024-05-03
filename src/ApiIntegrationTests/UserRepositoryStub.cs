using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTests
{
    public class UserRepositoryStub : IUserRepository
    {
        public Task AddAsync(User userDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var queryResult =
                    new UserDto {
                        Id = Guid.NewGuid(),
                        Name = "test",
                        Email = "test@test.com"
                };

            return Task.FromResult(queryResult);
        }

        public Task<GetAllResponseWithPagination<UserDto>> GetUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUsersByLoginAsync(GetUsersByLoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetUsersByNameAsync(GetUsersByNameRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetUsersBySpecificationAsync(Specification<User> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDto userDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
