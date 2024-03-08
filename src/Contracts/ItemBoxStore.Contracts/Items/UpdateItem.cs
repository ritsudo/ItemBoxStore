using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{

    public class UpdateItem
    {
        /// <summary>
        /// Запрос для обновления объявления
        /// </summary>
        public class UpdateItemRequest
        {
            /// <summary>
            /// Идентификатор обновляемого объявления
            /// </summary>
            public Guid Id { get; set; }

            /// <summary>
            /// Новое название объявления
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Новый ID подкатегории объявления
            /// </summary>
            public int SubCategoryId { get; set; }

            /// <summary>
            /// Новое описание объявления
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Новая стоимость товара
            /// </summary>
            public decimal Price { get; set; }
        }
    }
}
