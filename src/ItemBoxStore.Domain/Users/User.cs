using ItemBoxStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Domain.Users
{
    /// <summary>
    /// Класс для пользователей (не включая пароли)
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required]
        public required string Login { get; set; }
        /// <summary>
        /// E-mail пользователя
        /// </summary>
        [Required]
        public required string Email { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        public required string Name { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        [Required]
        public required string Phone { get; set; }
    }
}
