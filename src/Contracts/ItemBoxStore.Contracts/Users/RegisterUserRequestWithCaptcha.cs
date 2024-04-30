using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Users
{
    /// <summary>
    /// Модель создания пользователя
    /// </summary>
    public class RegisterUserRequestWithCaptcha : RegisterUserRequest
    {
        /// <summary>
        /// Ключ капчи
        /// </summary>
        public string dntCaptchaText { get; set; }
        /// <summary>
        /// Токен капчи
        /// </summary>
        public string dntCaptchaToken { get; set; }
        /// <summary>
        /// Входной текст от пользователя
        /// </summary>
        public string dntCaptchaInputText { get; set; }
    }
}
