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
    public class ConfirmEmailRequest
    {
        /// <summary>
        /// Токен подтверждения пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите токен подтверждения")]
        public Guid ConfirmationToken { get; set; }
    }
}
