using Moq;
using ItemBoxStore.Application.Contexts.User.Services;
using ItemBoxStore.Application.Repositories;
using AutoMapper;
using ItemBoxStore.Application.Contexts.User.Services.Definitions;
using ItemBoxStore.Contracts.StorageFiles;

namespace Academy.ItemBoxStore.UnitTests.Services
{
    public class StorageFileServiceTests
    {

        private readonly Mock<IStorageFileRepository> _storagefileRepositoryMock;
        private readonly IStorageFileService _storagefileService;

        public StorageFileServiceTests()
        {
            //Настройка Mock'ов
            Mock<IMapper> mapper = new Mock<IMapper>();
            _storagefileRepositoryMock = new Mock<IStorageFileRepository>();
            _storagefileService = new StorageFileService(_storagefileRepositoryMock.Object, mapper.Object);
        }

        /// <summary>
        /// Добавление файла должно возвращать результат
        /// </summary>
        [Fact]
        public void StorageFileService_AddAsync_Should_ReturnResult()
        {
            // Arrange
            var storagefileRequest = new FileDto();
            var cancellationToken = new CancellationTokenSource().Token;

            // Act
            var result = _storagefileService.UploadAsync(storagefileRequest, cancellationToken);

            // Assert
            Assert.IsType<Task<Guid>>(result);
        }

    }
}