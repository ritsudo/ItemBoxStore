using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Users
{
    /// <summary>
    /// Запрос получения всех пользователей (с пагинацией)
    /// </summary>
    public class GetAllUsersRequest
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
