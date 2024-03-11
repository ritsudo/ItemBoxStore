using ItemBoxStore.Contracts.Items;
using ItemBoxStore.Contracts.Users;
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
        public Task<IReadOnlyCollection<GetItem.GetItemResponse>> GetItemsAsync(CancellationToken cancellationToken);
    }
}
