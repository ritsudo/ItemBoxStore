using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    public class ItemDto
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public Guid Id { get; set; }

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
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Состояние объявления
        /// </summary>
        public enum Status
        {
            Opened,
            Closed
        }


    }
}
