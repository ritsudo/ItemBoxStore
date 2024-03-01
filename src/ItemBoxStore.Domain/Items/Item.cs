using ItemBoxStore.Domain.Base;
using ItemBoxStore.Domain.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [MaxLength(100)]
        public required string Name {  get; set; }

        /// <summary>
        /// ID подкатегории объявления
        /// </summary>
        [Required]
        public required int SubCategoryId { get; set; };

        /// <summary>
        /// Описание объявления
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public required string Description { get; set; }

        /// <summary>
        /// Стоимость товара
        /// </summary>
        [Required]
        public required decimal Price { get; set; }

        /// <summary>
        /// ID автора объявления
        /// </summary>
        [Required]
        public required int AuthorId { get; set; }

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
