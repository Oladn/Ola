using Ola.Extensions.Categories;

namespace Ola.Extensions.Identity.Events
{
    /// <summary>
    /// 事件类型管理接口。
    /// </summary>
    public interface IEventTypeManager : ICachableCategoryManager<EventType>, ISingletonService
    {

    }
}