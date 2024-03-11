using ItemBoxStore.Application.Repositories;
using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Infrastructure.DataAccess.Repositories
{
    /// <inheritdoc />
    public class ItemRepository : IItemRepository
    {
        /// <inheritdoc/>
        public Task<IReadOnlyCollection<GetItem.GetItemResponse>> GetItemsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
