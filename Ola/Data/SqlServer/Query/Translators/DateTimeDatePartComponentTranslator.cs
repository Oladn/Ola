using System;
using System.Linq.Expressions;
using Ola.Data.Query.Translators;
using Ola.Data.SqlServer.Query.Expressions;

namespace Ola.Data.SqlServer.Query.Translators
{
    /// <summary>
    /// 日期部分转换器。
    /// </summary>
    public class DateTimeDatePartComponentTranslator : IMemberTranslator
    {
        /// <summary>
        /// 转换字段或属性表达式。
        /// </summary>
        /// <param name="memberExpression">转换字段或属性表达式。</param>
        /// <returns>转换后的表达式。</returns>
        public virtual Expression Translate(MemberExpression memberExpression)
        {
            string datePart;
            if (memberExpression.Expression != null
                && memberExpression.Expression.Type == typeof(DateTime)
                && (datePart = GetDatePart(memberExpression.Member.Name)) != null)
            {
                return new DatePartExpression(datePart,
                    memberExpression.Type,
                    memberExpression.Expression);
            }
            return null;
        }

        private static string GetDatePart(string memberName)
        {
            return memberName switch
            {
                nameof(DateTime.Year) => "year",
                nameof(DateTime.Month) => "month",
                nameof(DateTime.DayOfYear) => "dayofyear",
                nameof(DateTime.Day) => "day",
                nameof(DateTime.Hour) => "hour",
                nameof(DateTime.Minute) => "minute",
                nameof(DateTime.Second) => "second",
                nameof(DateTime.Millisecond) => "millisecond",
                _ => null,
            };
        }
    }
}