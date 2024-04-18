using Xunit;
using Moq;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Application.Repositories;
using AutoMapper;
using ItemBoxStore.Contracts.Users;

namespace Academy.ItemBoxStore.UnitTests
{
    public class UserServiceTests
    {

        [Fact]
        public void UserService_AddAsync_ReturnTask()
        {
            
            // Arrange
            var mockDependency1 = new Mock<IUserRepository>();
            var mockDependency2 = new Mock<IMapper>();

            var service = new UserService(mockDependency1.Object, mockDependency2.Object);

            var userRequest = new RegisterUserRequest();
            var cancellationToken = new CancellationToken();

            // Act
            var result = service.AddAsync(userRequest, cancellationToken);

            // Assert
            Assert.IsType<Task<Guid>>(result);
            
        }
    }
}