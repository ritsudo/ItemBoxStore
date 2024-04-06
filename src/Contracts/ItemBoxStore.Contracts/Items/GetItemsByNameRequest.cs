using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    /// <summary>
    /// Запрос получения предмета по названию
    /// </summary>
    public class GetItemsByNameRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название объявления")]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
