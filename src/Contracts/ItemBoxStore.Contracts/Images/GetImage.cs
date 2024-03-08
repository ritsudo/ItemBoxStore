using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Images
{
    /// <summary>
    /// Класс, описывающий получаемое изображение
    /// </summary>
    public class GetImage
    {
        /// <summary>
        /// Запрос ID получаемой картинки
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Идентификатор получаемого изображения
            /// </summary>
            public Guid Id { get; set; }
        }

        /// <summary>
        /// Данные о получаемой картинке
        /// </summary>
        public class Response
        {
            /// <summary>
            /// Название изображения
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// Тип изображения
            /// </summary>
            public string ContentType { get; set; }
            /// <summary>
            /// Название картинки в хранилище
            /// </summary>
            public string FilePath { get; set; }
        }
    }
}
