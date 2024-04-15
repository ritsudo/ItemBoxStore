﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Contracts.Items
{
    /// <summary>
    /// Класс расширенной информации об объявлении
    /// </summary>
    public class ItemDtoDetailed : ItemDto
    {

        /// <summary>
        /// Имя автора объявления
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// ID аватара автора объявления
        /// </summary>
        public Guid AuthorAvatarId { get; set; }

    }
}