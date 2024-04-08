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
            [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название объявления (до 30 символов)")]
            [StringLength(30)]
            public string Name { get; set; }

            /// <summary>
            /// ID подкатегории объявления
            /// </summary>
            [Required]
            [Range(1, 100)]
            public int SubCategoryId { get; set; }

            /// <summary>
            /// Описание объявления
            /// </summary>
            [Required(AllowEmptyStrings = false, ErrorMessage = "Введите описание объявления (до 500 символов)")]
            [StringLength(500)]
            public string Description { get; set; }

            /// <summary>
            /// Стоимость товара
            /// </summary>
            [Required]
            [Range(1, 100000000)]
            public decimal Price { get; set; }
        }
}
