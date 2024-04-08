using System.ComponentModel.DataAnnotations;

namespace ItemBoxStore.Contracts.Items
{
    /// <summary>
    /// Запрос получения предмета по названию
    /// </summary>
    public class GetItemsByNameRequest
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите название объявления")]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
