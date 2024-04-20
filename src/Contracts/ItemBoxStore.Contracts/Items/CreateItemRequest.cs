using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
        /// <summary>
        /// Запрос для создания нового объявления
        /// </summary>
        public class CreateItemRequest
        {
            /// <summary>
            /// Название объявления
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// ID подкатегории объявления
            /// </summary>
            public int SubCategoryId { get; set; }

            /// <summary>
            /// Описание объявления
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Локация объявления
            /// </summary>
            public string Location { get; set; }

            /// <summary>
            /// Стоимость товара
            /// </summary>
            public decimal Price { get; set; }
        }
}
