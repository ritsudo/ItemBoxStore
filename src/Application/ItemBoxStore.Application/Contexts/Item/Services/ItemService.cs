using ItemBoxStore.Contracts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Application.Contexts.Item.Services
{
    /// <summary>
    /// Инициализирует экземпляр UserService
    /// </summary>
    public class ItemService : IItemService
    {
        /// <inheritdoc/>
        public Task AddImage(AddImage.AddImageRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Guid> CreateAsync(CreateItem.CreateItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task Delete(DeleteItem.DeleteItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetPaged.GetPagedResponse> GetAll(GetPaged.GetPagedRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetItem.GetItemResponse> GetById(GetItem.GetItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Guid> UpdateAsync(UpdateItem.UpdateItemRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetPaged.GetPagedResponse> GetPaged(GetPaged.GetPagedRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
