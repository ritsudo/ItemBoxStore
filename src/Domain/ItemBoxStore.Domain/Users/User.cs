using ItemBoxStore.Domain.Base;
using System;
using System.Collections.Generic;
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
        public string Login { get; set; }
        /// <summary>
        /// E-mail пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
    }
}
