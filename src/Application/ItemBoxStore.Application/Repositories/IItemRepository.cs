using ItemBoxStore.Application.Specifications;
using ItemBoxStore.Contracts;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Domain.Items;
using ItemBoxStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Repositories
{
    /// <summary>
    /// Репозиторий для работы с предметами
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// Получить список предметов
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<GetAllResponseWithPagination<ItemDto>> GetItemsAsync(GetAllItemsRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список предметов по имени
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<ItemDto>> GetItemsByNameAsync(GetItemsByNameRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список предметов по спецификации
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<ItemDto>> GetItemsBySpecificationAsync(Specification<Item> request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить предмет по ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<ItemDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать предмет
        /// </summary>
        /// <param name="itemDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AddAsync(Item itemDto, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить предмет
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public Task UpdateAsync(ItemDto itemDto, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить предмет
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
