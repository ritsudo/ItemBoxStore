using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Domain.Base
{
    /// <summary>
    /// Базовый класс всех сущностей
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Идентификатор сущности
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата создания сущности
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата обновления сущности (nullable)
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Дата удаления сущности (nullable)
        /// </summary>
        public DateTime DeleteDate { get; set; }
    }
}
