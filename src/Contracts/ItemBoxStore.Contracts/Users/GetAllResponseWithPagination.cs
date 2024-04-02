using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Users
{
    /// <summary>
    /// Ответ на запрос получения данных
    /// </summary>
    public class GetAllResponseWithPagination<T>
    {
        /// <summary>
        /// Коллекция с результатом
        /// </summary>
        public IEnumerable<T> Result { get; set; }
        /// <summary>
        /// Количество элементов на одной странице
        /// </summary>
        public int TotalPages { get; set; }
    }
}
