﻿using System.ComponentModel.DataAnnotations.Schema;
using Ola.Extensions;

namespace Ola.Apis.Entities
{
    /// <summary>
    /// API服务。
    /// </summary>
    [Table("apis_Services")]
    public class ApiService
    {
        /// <summary>
        /// 唯一Id。
        /// </summary>
        [Identity]
        public int Id { get; set; }

        /// <summary>
        /// 分类Id。
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// API名称。
        /// </summary>
        [Size(64)]
        public string Name { get; set; }

        /// <summary>
        /// 描述。
        /// </summary>
        [NotUpdated]
        public string Description { get; set; }

        /// <summary>
        /// 是否禁用。
        /// </summary>
        public bool Disabled { get; set; }
    }
}