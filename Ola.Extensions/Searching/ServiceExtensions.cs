using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ola.Data.Migrations;
using Ola.Extensions.Tasks;

namespace Ola.Extensions.Searching
{
    /// <summary>
    /// 服务扩展。
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 开启Email功能。
        /// </summary>
        /// <param name="builder">容器构建实例。</param>
        /// <returns>返回容器构建实例。</returns>
        public static IOlaBuilder AddSearching(this IOlaBuilder builder)
        {
            return builder.AddServices(services =>
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient<IDataMigration, SearchDataMigration>());
                services.TryAddEnumerable(ServiceDescriptor.Singleton<ITaskService, SearchTaskService>());
            });
        }
    }
}