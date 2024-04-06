using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using static ItemBoxStore.Contracts.Items.CreateItem;

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
        Task<Guid> AddAsync(CreateItemRequest model, CancellationToken cancellationToken);

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
        /// Получить объявления по id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Пользователь</returns>
        ValueTask<ItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Список абсолютно всех пользователей</returns>
        public Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все объявления по имени
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Коллекция моделей пользователей</returns>
        public Task<IEnumerable<ItemDto>> GetItemsByNameAsync(GetItemsByNameRequest request, CancellationToken cancellationToken);
    }
}
