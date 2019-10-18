using System;
using System.Collections.Generic;
using System.Linq;

namespace Ola.Extensions
{
    /// <summary>
    /// 父子级操作辅助类。
    /// </summary>
    public static class ParentableExtensions
    {
        /// <summary>
        /// 具有上下级关系的模型进行封装，将对象添加到父级或子集对象中，从而可以访问父级或子集对象实例。
        /// </summary>
        /// <param name="models">当前从数据库中获取的模型列表。</param>
        /// <returns>返回当前ID实例。</returns>
        public static IDictionary<int, TModel> MakeDictionary<TModel>(this IEnumerable<TModel> models)
            where TModel : IParentable<TModel>
        {
            var dic = models.ToDictionary(c => c.Id);
            dic[0] = Activator.CreateInstance<TModel>();
            foreach (var model in models)
            {
                if (dic.TryGetValue(model.ParentId, out var temp))
                    temp.Add(model);
            }
            return dic;
        }
    }
}