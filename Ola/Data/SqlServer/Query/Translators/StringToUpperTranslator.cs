using Ola.Data.Query.Translators;

namespace Ola.Data.SqlServer.Query.Translators
{
    /// <summary>
    /// 大写转换。
    /// </summary>
    public class StringToUpperTranslator : ParameterlessInstanceMethodCallTranslator
    {
        /// <summary>
        /// 初始化类<see cref="StringToUpperTranslator"/>。
        /// </summary>
        public StringToUpperTranslator()
            : base(typeof(string), nameof(string.ToUpper), "UPPER")
        {
        }
    }
}