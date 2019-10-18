using Ola.Extensions.Categories;

namespace Ola.Extensions.Messages.Notifications
{
    /// <summary>
    /// 系统通知类型管理接口。
    /// </summary>
    public interface INotificationTypeManager : ICachableCategoryManager<NotificationType>, ISingletonService { }
}