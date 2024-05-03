using Xunit;
using Moq;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Application.Repositories;
using AutoMapper;
using ItemBoxStore.Contracts.Users;
using AutoFixture;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Domain.Users;
using Shouldly;

namespace Academy.ItemBoxStore.UnitTests.Services
{
    public class UserServiceTests
    {

        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            //Настройка Mock'ов
            Mock<IMapper> mapper = new();
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object, mapper.Object);
        }

        /// <summary>
        /// Получение пользователя должно возвращать результат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetUsersByNameAsync_Should_ReturnCorrectResult()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture
                .Build<GetUsersByNameRequest>()
                .With(x => x.IsEmailConfirmed, false)
                .Create();

            var cancellationToken = new CancellationTokenSource().Token;

            _userRepositoryMock
                .Setup(x => x.GetUsersBySpecificationAsync(It.IsAny<Specification<User>>(), cancellationToken))
                .ReturnsAsync(new List<UserDto>());

            // Act
            var result = await _userService.GetUsersByNameAsync(request, cancellationToken);

            //Assert
            Assert.NotNull(result);
            result.ShouldNotBeNull();
            result.Count().ShouldBe(0);
            _userRepositoryMock.Verify(
                x => x.GetUsersBySpecificationAsync(
                    It.Is<Specification<User>>
                        (s => CheckByNameSpecification(s)), cancellationToken),
                Times.Once);
        }


        /// <summary>
        /// Добавление пользователя должно возвращать результат
        /// </summary>
        [Fact]
        public void UserService_AddAsync_Should_ReturnResult()
        {
            // Arrange
            var userRequest = new RegisterUserRequest();
            var cancellationToken = new CancellationTokenSource().Token;

            // Act
            var result = _userService.AddAsync(userRequest, cancellationToken);

            // Assert
            Assert.IsType<Task<Guid>>(result);

        }

        private bool CheckByNameSpecification(Specification<User> specification) =>
            specification.GetType() == typeof(UserByNameSpecification);
    }
}