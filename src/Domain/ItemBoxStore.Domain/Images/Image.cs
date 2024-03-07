using ItemBoxStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Domain.Images
{
    /// <summary>
    /// Класс для сущности изображения
    /// </summary>
    public class Image : BaseEntity
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
