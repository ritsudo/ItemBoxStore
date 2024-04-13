using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Users
{
    /// <summary>
    /// Модель входа для пользователя
    /// </summary>
    public class LoginUserRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите id пользователя")]
        [StringLength(50)]
        public string UserId { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
