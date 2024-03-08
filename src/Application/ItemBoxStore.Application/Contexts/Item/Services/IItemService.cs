using ItemBoxStore.Contracts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Contexts.Item.Services
{
    public interface IItemService
    {
        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CreateItem.Response> Create(CreateItem.Request request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить объявление по ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetItem.Response> GetById(GetItem.Request request, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task <UpdateItem.Response> Update(UpdateItem.Request request, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Delete(DeleteItem.Request request, CancellationToken cancellationToken);

        /// <summary>
        /// Получить страницу с объявлениями (offset, count)
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetPaged.Response> GetPaged(GetPaged.Request request, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить картинку в объявление
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddImage(AddImage.Request request, CancellationToken cancellationToken);
    }
}
