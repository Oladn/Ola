using System;
using Ola.Data.Query.Translators;

namespace Ola.Data.SqlServer.Query.Translators
{
    /// <summary>
    /// Math.Pow转换器。
    /// </summary>
    public class MathPowerTranslator : SingleOverloadStaticMethodCallTranslator
    {
        /// <summary>
        /// 初始化类<see cref="MathPowerTranslator"/>。
        /// </summary>
        public MathPowerTranslator()
            : base(typeof(Math), nameof(Math.Pow), "POWER")
        {
        }
    }
}