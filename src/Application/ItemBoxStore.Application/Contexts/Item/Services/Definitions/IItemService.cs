using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using static ItemBoxStore.Contracts.Items.CreateItemRequest;

namespace ItemBoxStore.Application.Contexts.Item.Services.Definitions
{
    public interface IItemService
    {
        /// <summary>
        /// Регистрация объявления
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Guid> AddAsync(ItemDtoDetailed model, CancellationToken cancellationToken);

        /// <summary>
        /// Обновление объявления
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateAsync(ItemDto model, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление объявления
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Замена изображения объявлению
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ModifyImage(ModifyImageRequest model, CancellationToken cancellationToken);

        /// <summary>
        /// Получить объявления по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Пользователь</returns>
        ValueTask<ItemDtoDetailed> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список абсолютно всех объявлений</returns>
        public Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все объявления по имени
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Коллекция моделей объявления</returns>
        public Task<IEnumerable<ItemDto>> GetItemsByNameAsync(GetItemsByNameRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все объявления пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Коллекция моделей объявлений</returns>
        public Task<IEnumerable<ItemDto>> GetItemsByUserIdAsync(Guid id, CancellationToken cancellationToken);

    }
}
