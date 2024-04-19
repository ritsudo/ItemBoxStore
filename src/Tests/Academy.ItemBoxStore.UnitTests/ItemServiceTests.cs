using AutoFixture;
using AutoMapper;
using ItemBoxStore.Application.Contexts.Item.Services.Definitions;
using ItemBoxStore.Application.Contexts.Item.Services.Implementations;
using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Items;
using Moq;
using Shouldly;

namespace Academy.ItemBoxStore.UnitTests
{
    public class ItemServiceTests
    {

        private readonly Mock<IItemRepository> _itemRepositoryMock;
        private readonly IItemService _itemService;

        public ItemServiceTests()
        {
            //Настройка Mock'ов
            Mock<IMapper> mapper = new Mock<IMapper>();
            _itemRepositoryMock = new Mock<IItemRepository>();
            _itemService = new ItemService(_itemRepositoryMock.Object, mapper.Object);
        }

        [Fact]
        public async Task GetItemsByNameAsync_Should_ReturnCorrectResult()
        {
            // Arrange
            var fixture = new Fixture();
            var request = fixture
                .Build<GetItemsByNameRequest>()
                .Create();

            var cancellationToken = new CancellationTokenSource().Token;

            _itemRepositoryMock
                .Setup(x => x.GetItemsBySpecificationAsync(It.IsAny<Specification<Item>>(), cancellationToken))
                .ReturnsAsync(new List<ItemDto>());

            // Act
            var result = await _itemService.GetItemsByNameAsync(request, cancellationToken);

            //Assert
            Assert.NotNull(result);
            result.ShouldNotBeNull();
            result.Count().ShouldBe(0);
            _itemRepositoryMock.Verify(
                x => x.GetItemsBySpecificationAsync(
                    It.Is<Specification<Item>>
                        (s => CheckByNameSpecification(s)), cancellationToken),
                Times.Once);
        }


        [Fact]
        public void ItemService_AddAsync_Should_ReturnResult()
        {
            // Arrange
            var itemRequest = new ItemDtoDetailed();
            var cancellationToken = new CancellationTokenSource().Token;

            // Act
            var result = _itemService.AddAsync(itemRequest, cancellationToken);

            // Assert
            Assert.IsType<Task<Guid>>(result);

        }

        private bool CheckByNameSpecification(Specification<Item> specification) =>
            specification.GetType() == typeof(ItemByNameSpecification);
    }
}