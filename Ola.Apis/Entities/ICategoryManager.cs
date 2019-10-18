using Ola.Extensions.Categories;

namespace Ola.Apis.Entities
{
    /// <summary>
    /// 分类接口。
    /// </summary>
    public interface ICategoryManager : ICachableCategoryManager<Category>, ISingletonService
    {

    }
}