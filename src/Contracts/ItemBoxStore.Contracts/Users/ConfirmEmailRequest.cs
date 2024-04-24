using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Users
{
    /// <summary>
    /// Запрос получения пользователя по имени
    /// </summary>
    public class GetUsersByLoginRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя")]
        [StringLength(30)]
        public string Login { get; set; }
    }
}
