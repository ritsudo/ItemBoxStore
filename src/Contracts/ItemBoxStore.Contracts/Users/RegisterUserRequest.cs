﻿using System;
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
    public class RegisterUserRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите логин")]
        [StringLength(30)]
        public string Login { get; set; }
        /// <summary>
        /// E-mail пользователя
        /// </summary>
        [Required(ErrorMessage = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя пользователя")]
        [StringLength(30)]
        public string Name { get; set; }
        /// <summary>
        /// Телефон  пользователя
        /// </summary>
        [Required(ErrorMessage = "Введите телефонный номер")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Введите корректный телефонный номер")]
        public string Phone { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required(ErrorMessage = "Введите свой пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}