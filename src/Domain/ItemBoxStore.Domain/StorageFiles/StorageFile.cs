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
    public class StorageFile : BaseEntity
    {
        /// <summary>
        /// Название файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Содержание файла
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Тип файла
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Длина содержимого файла
        /// </summary>
        public int FileLength { get;set; }

        /// <summary>
        /// Название картинки в хранилище
        /// </summary>
        public string FilePath { get; set; }
    }
}
