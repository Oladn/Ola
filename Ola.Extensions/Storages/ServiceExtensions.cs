using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ola.Data.Migrations;
using Ola.Extensions.Tasks;

namespace Ola.Extensions.Storages
{
    /// <summary>
    /// 服务扩展类。
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 添加存储服务，只有添加了存储服务后才可以使用媒体存储功能。
        /// </summary>
        /// <param name="builder">Ola容器构建实例。</param>
        /// <param name="includeCache">是否包含文件缓存功能。</param>
        /// <returns>返回容器构建实例。</returns>
        public static IOlaBuilder UseStorages(this IOlaBuilder builder, bool includeCache = false)
        {
            return builder.AddServices(services =>
            {
                services.TryAddEnumerable(ServiceDescriptor.Singleton<ITaskService, StorageTaskService>());
                services.TryAddEnumerable(ServiceDescriptor.Transient<IDataMigration, MediaDataMigration>());
                if (includeCache)
                    services.TryAddEnumerable(ServiceDescriptor.Transient<IDataMigration, CacheDataMigration>());
            });
        }
    }
}