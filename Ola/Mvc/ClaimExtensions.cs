using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Ola.Mvc
{
    /// <summary>
    /// 声明扩展。
    /// </summary>
    public static class ClaimExtensions
    {
        /// <summary>
        /// 获取声明值。
        /// </summary>
        /// <param name="context">HTTP上下文。</param>
        /// <param name="type">声明类型。</param>
        /// <returns>返回声明值。</returns>
        public static string GetClaimValue(this HttpContext context, string type)
        {
            return context.User.FindFirst(type)?.Value;
        }

        /// <summary>
        /// 获取声明值。
        /// </summary>
        /// <param name="context">HTTP上下文。</param>
        /// <param name="type">声明类型。</param>
        /// <returns>返回声明值。</returns>
        public static IEnumerable<string> GetClaimValues(this HttpContext context, string type)
        {
            return context.User.FindAll(type)?.Select(x => x.Value);
        }

        /// <summary>
        /// 获取用户Id。
        /// </summary>
        /// <param name="context">HTTP上下文。</param>
        /// <returns>返回用户Id。</returns>
        public static int GetUserId(this HttpContext context)
        {
            if (int.TryParse(context.GetClaimValue(ClaimTypes.NameIdentifier), out var value))
                return value;
            return 0;
        }

        /// <summary>
        /// 获取用户名称。
        /// </summary>
        /// <param name="context">HTTP上下文。</param>
        /// <returns>返回用户Id。</returns>
        public static string GetUserName(this HttpContext context) => context.GetClaimValue(ClaimTypes.Name);
    }
}