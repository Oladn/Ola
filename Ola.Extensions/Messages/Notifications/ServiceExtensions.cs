using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ola.Data.Migrations;
using Ola.Extensions.Tasks;

namespace Ola.Extensions.Messages.Notifications
{
    /// <summary>
    /// 服务扩展。
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 开启提示功能。
        /// </summary>
        /// <param name="builder">容器构建实例。</param>
        /// <returns>返回容器构建实例。</returns>
        public static IOlaBuilder UseNotification(this IOlaBuilder builder)
        {
            return builder.AddServices(services =>
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient<IDataMigration, NotificationDataMigration>());
                services.TryAddEnumerable(ServiceDescriptor.Singleton<ITaskService, NotificationTaskService>());
            });
        }
    }
}