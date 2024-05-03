using AutoMapper;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Infrastructure;
using ItemBoxStore.Infrastructure.DataAccess.Repositories.Items;
using ItemBoxStore.Infrastructure.MapProfiles;
using ItemBoxStore.Infrastructure.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academy.ItemBoxStore.UnitTests.RepositoryTests
{
    /// <summary>
    /// Тесты <see cref="ItemRepository"/>
    /// </summary>
    public class ItemRepositoryTests
    {
        private readonly IMapper _mapper;

        private IRepository<Item> _repository;
        private IReadOnlyRepository<Item> _readOnlyRepository;
        private IItemRepository _itemRepository;

        public ItemRepositoryTests() {
            _mapper = new MapperConfiguration(configure => configure.AddProfile(new ItemProfile())).CreateMapper();
        }

        /// <summary>
        /// ItemRepository тест - выдаёт ли результат запроса
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

            _repository = new Repository<Item>(context);
            _readOnlyRepository = new ReadOnlyRepository<Item>(context);
            _itemRepository = new ItemRepository(_repository, _readOnlyRepository, _mapper);

            var request = new GetAllItemsRequest();
            var cancellationToken = new CancellationTokenSource().Token;
            Expression<Func<Item, object>> orderByExpression = orderByExpression = item => item.Id;

            //Act
            var allItems = await _itemRepository.GetItemsAsync(request, orderByExpression, cancellationToken);
            var result = allItems.Result.ToArray();

            // Assert
            Assert.NotNull(allItems);
            Assert.Equal(1, allItems.TotalPages);
            Assert.Empty(result);
        }

        /// <summary>
        /// ItemRepository тест - выдаёт ли результат запроса
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Repository_GetAll_Returns_Items_Sqlite()
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

            context.AddRange(GenerateNewRandomItem(rnd), GenerateNewRandomItem(rnd));

            context.SaveChanges();

            _repository = new Repository<Item>(context);
            _readOnlyRepository = new ReadOnlyRepository<Item>(context);
            _itemRepository = new ItemRepository(_repository, _readOnlyRepository, _mapper);

            var request = new GetAllItemsRequest();
            var cancellationToken = new CancellationTokenSource().Token;
            Expression<Func<Item, object>> orderByExpression = orderByExpression = item => item.Id;

            //Act
            var allItems = await _itemRepository.GetItemsAsync(request, orderByExpression, cancellationToken);
            var result = allItems.Result.ToArray();

            // Assert
            Assert.NotNull(allItems);
            Assert.Equal(1, allItems.TotalPages);
            Assert.Equal(2, result.Length);
        }

        private static Item GenerateNewRandomItem(Random rnd) => new Item
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow,
            Name = "Item" + rnd.Next(0, 1001),
            SubCategoryId = 5,
            Description = "Test" + rnd.Next(0, 1001),
            Location = "Test" + rnd.Next(0, 1001),
            Price = rnd.Next(1, 1000000),
            AuthorId = new Guid()
        };
    }
}
