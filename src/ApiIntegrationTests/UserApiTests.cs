using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using ItemBoxStore.Domain.Items;
using System.Net;
using System.Net.Http.Json;

namespace ApiIntegrationTests
{
    public class UserApiTests : IClassFixture<WebApplicationFactory>
    {
        private readonly WebApplicationFactory _webApplicationFactory;
        public UserApiTests(WebApplicationFactory webApplicationFactory) 
        {
            _webApplicationFactory = webApplicationFactory;
        }

        /// <summary>
        /// Проверяет, выдаёт ли "получить пользователя по Id" результат
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetUserById_Request_ReturnsSucess()
        {
            // Arrange
            var httpClient = _webApplicationFactory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("User/d6362612-796e-4b27-bcce-88f0d9d7a3a0", CancellationToken.None);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}