using AutoMapper;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Domain.Users;
using ItemBoxStore.Infrastructure;
using ItemBoxStore.Infrastructure.DataAccess.Repositories;
using ItemBoxStore.Infrastructure.MapProfiles;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Academy.ItemBoxStore.UnitTests.RepositoryTests
{
    /// <summary>
    /// Тесты <see cref="UserRepository"/>
    /// </summary>
    public class UserRepositoryTests
    {
        private readonly IMapper _mapper;

        private IRepository<User> _repository;
        private IReadOnlyRepository<User> _readOnlyRepository;
        private IUserRepository _userRepository;

        public UserRepositoryTests() {
            _mapper = new MapperConfiguration(configure => configure.AddProfile(new UserProfile())).CreateMapper();
        }

        /// <summary>
        /// UserRepository тест - выдаёт ли результат запроса
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Repository_GetAll_Returns_List_Sqlite()
        {
            // Arrange
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();

            _repository = new Repository<User>(context);
            _readOnlyRepository = new ReadOnlyRepository<User>(context);
            _userRepository = new UserRepository(_repository, _readOnlyRepository, _mapper);

            var request = new GetAllUsersRequest();
            var cancellationToken = new CancellationTokenSource().Token;

            //Act
            var allUsers = await _userRepository.GetUsersAsync(request, cancellationToken);
            var result = allUsers.Result.ToArray();

            // Assert
            Assert.NotNull(allUsers);
            Assert.Equal(1, allUsers.TotalPages);
            Assert.Empty(result);
        }

        /// <summary>
        /// UserRepository тест - выдаёт ли результат запроса
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Repository_GetAll_Returns_Users_Sqlite()
        {
            // Arrange
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Random rnd = new Random();

            context.AddRange(GenerateNewRandomUser(rnd), GenerateNewRandomUser(rnd));

            context.SaveChanges();

            _repository = new Repository<User>(context);
            _readOnlyRepository = new ReadOnlyRepository<User>(context);
            _userRepository = new UserRepository(_repository, _readOnlyRepository, _mapper);

            var request = new GetAllUsersRequest();
            var cancellationToken = new CancellationTokenSource().Token;

            //Act
            var allUsers = await _userRepository.GetUsersAsync(request, cancellationToken);
            var result = allUsers.Result.ToArray();

            // Assert
            Assert.NotNull(allUsers);
            Assert.Equal(1, allUsers.TotalPages);
            Assert.Equal(2, result.Length);
        }

        private static User GenerateNewRandomUser(Random rnd) => new User
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Login = "Vasya" + rnd.Next(0, 1001),
            Name = "Vasya",
            Email = "test@example.com",
            EmailConfirmed = false,
            Phone = "+71231234567",
            PasswordHash = "testHash"
        };
    }
}
