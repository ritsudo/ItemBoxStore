using ItemBoxStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Domain.Categories
{
    /// <summary>
    /// Класс для категорий
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// Список подкатегорий
        /// </summary>
        public ICollection<SubCategory> SubCategories { get; set; };
    }
}
