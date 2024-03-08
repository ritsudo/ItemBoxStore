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
        public Task AddImage(AddImage.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateAsync(CreateItem.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DeleteItem.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetItem.Response> GetById(GetItem.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<GetPaged.Response> GetPaged(GetPaged.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateItem.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
