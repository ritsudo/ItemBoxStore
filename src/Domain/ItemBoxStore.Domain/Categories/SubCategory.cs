﻿using ItemBoxStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBoxStore.Domain.Categories
{
    /// <summary>
    /// Класс для подкатегорий
    /// </summary>
    public class SubCategory : BaseEntity
    {
        /// <summary>
        /// Название подкатегории
        /// </summary>
        public required string SubCategoryName { get; set; }
        /// <summary>
        /// Id родительской категории
        /// </summary>
        public int CategoryId { get; set; }
    }
}
