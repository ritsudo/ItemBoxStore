using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    public class DeleteItem
    {
        /// <summary>
        /// Запрос для удаления объявления
        /// </summary>
        public class DeleteItemRequest
        {
            /// <summary>
            /// Идентификатор удаляемого объявления
            /// </summary>
            public Guid Id { get; set; }
        }
    }
}
