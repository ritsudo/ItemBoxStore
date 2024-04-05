using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.StorageFiles
{
    /// <summary>
    /// Модель файла
    /// </summary>
    public class FileDto
    {
        /// <summary>
        /// Имя файла.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Контент файла.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Тип контента.
        /// </summary>
        public string ContentType { get; set; }
    }
}