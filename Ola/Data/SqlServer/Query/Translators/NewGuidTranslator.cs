﻿using System;
using Ola.Data.Query.Translators;

namespace Ola.Data.SqlServer.Query.Translators
{
    /// <summary>
    /// NewGuid表达式转换接口。
    /// </summary>
    public class NewGuidTranslator : SingleOverloadStaticMethodCallTranslator
    {
        /// <summary>
        /// 初始化类<see cref="NewGuidTranslator"/>。
        /// </summary>
        public NewGuidTranslator()
            : base(typeof(Guid), nameof(Guid.NewGuid), "NEWID")
        {
        }
    }
}