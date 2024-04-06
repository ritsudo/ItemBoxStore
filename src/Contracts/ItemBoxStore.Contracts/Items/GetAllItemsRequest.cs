using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    /// <summary>
    /// Запрос получения всех предметов (с пагинацией)
    /// </summary>
    public class GetAllItemsRequest
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// Количество элементов на одной странице
        /// </summary>
        public int BatchSize { get; set; } = 10;
    }
}
