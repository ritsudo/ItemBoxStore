using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    /// <summary>
    /// Запрос для работы с картинками объявления
    /// </summary>
    public class ModifyImageRequest
    {
            /// <summary>
            /// Идентификатор изменяемого объявления
            /// </summary>
            public Guid ItemId { get; set; }

            /// <summary>
            /// Идентификатор изменяемой картинки
            /// </summary>
            public Guid ImageId { get; set; }
    }
}
