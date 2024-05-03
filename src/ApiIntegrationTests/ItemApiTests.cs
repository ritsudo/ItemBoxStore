using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Items;
using System.Net;
using System.Net.Http.Json;

namespace ApiIntegrationTests
{
    public class ItemApiTests : IClassFixture<WebApplicationFactory>
    {
        private readonly WebApplicationFactory _webApplicationFactory;
        public ItemApiTests(WebApplicationFactory webApplicationFactory) 
        {
            _webApplicationFactory = webApplicationFactory;
        }

        /// <summary>
        /// Проверяет, выдаёт ли "получить всё" результат <see cref="GetAllResponseWithPagination{T}"/>
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllItems_Request_ReturnsSucess()
        {
            // Arrange
            var httpClient = _webApplicationFactory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("Item/all", CancellationToken.None);
            var items = await response.Content.ReadFromJsonAsync<GetAllResponseWithPagination<ItemDto>>();

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Single(items.Result);
        }
    }
}