﻿using System.ComponentModel.DataAnnotations.Schema;
using Ola.Extensions.Categories;

namespace Ola.Extensions.Messages.Notifications
{
    /// <summary>
    /// 系统通知类型。
    /// </summary>
    [Table("core_Notifications_Types")]
    public class NotificationType : CategoryBase
    {
        /// <summary>
        /// 图标。
        /// </summary>
        [Size(256)]
        public string IconUrl { get; set; }

        /// <summary>
        /// 颜色。
        /// </summary>
        [Size(20)]
        public string Color { get; set; }
    }
}