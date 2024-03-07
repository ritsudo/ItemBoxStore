using ItemBoxStore.Domain.Base;
using ItemBoxStore.Domain.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Domain.Items
{
    /// <summary>
    /// Класс для объявлений
    /// </summary>
    public class Item : BaseEntity
    {
        /// <summary>
        /// Название объявления
        /// </summary>
        public string Name {  get; set; }

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
        public virtual ICollection<Image>? Images { get; set; }
    }
}
