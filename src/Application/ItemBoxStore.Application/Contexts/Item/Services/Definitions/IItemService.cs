using ItemBoxStore.Contracts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Contexts.Item.Services.Definitions
{
    public interface IItemService
    {
        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Guid> CreateAsync(CreateItem.CreateItemRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить объявление по ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetItem.GetItemResponse> GetById(GetItem.GetItemRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Guid> UpdateAsync(UpdateItem.UpdateItemRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Delete(DeleteItem.DeleteItemRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить получить все объявления
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetPaged.GetPagedResponse> GetAll(GetPaged.GetPagedRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить страницу с объявлениями (offset, count)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetPaged.GetPagedResponse> GetPaged(GetPaged.GetPagedRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить картинку в объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddImage(AddImage.AddImageRequest request, CancellationToken cancellationToken);
    }
}
