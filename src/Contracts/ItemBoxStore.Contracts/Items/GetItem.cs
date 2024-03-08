using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ItemBoxStore.Contracts.Items
{
    public class GetItem
    {
        /// <summary>
        /// Запрос для получения объявления
        /// </summary>
        public class GetItemRequest
        {
            /// <summary>
            /// Идентификатор получаемого объявления
            /// </summary>
            public Guid Id { get; set; }
        }

        /// <summary>
        /// Ответ - данные объявления
        /// </summary>
        public class GetItemResponse
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
            /// Стоимость товара
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// ID автора объявления
            /// </summary>
            public int AuthorId { get; set; }

            /// <summary>
            /// Состояние объявления
            /// </summary>
            public enum Status
            {
                Opened,
                Closed
            }

            /// <summary>
            /// Коллекция изображений
            /// </summary>
            ///public virtual ICollection<Image>? Images { get; set; }
        }
    }
}
