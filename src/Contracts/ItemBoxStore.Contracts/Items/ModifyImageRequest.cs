using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    public class ModifyImageRequest
    {
        /// <summary>
        /// Запрос для работы с картинками объявления
        /// </summary>
        public class DeleteItemRequest
        {
            /// <summary>
            /// Идентификатор изменяемого объявления
            /// </summary>
            public Guid Id { get; set; }

            /// <summary>
            /// Идентификатор изменяемой картинки
            /// </summary>
            public Guid Image_Id { get; set; }
        }
    }
}
