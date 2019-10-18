using Ola.Data.Migrations;
using Ola.Extensions.Storages.Caching;

namespace Ola.Extensions.Storages
{
    /// <summary>
    /// 缓存文件存储数据库迁移类。
    /// </summary>
    internal class CacheDataMigration : DataMigration
    {
        /// <summary>
        /// 当模型建立时候构建的表格实例。
        /// </summary>
        /// <param name="builder">迁移实例对象。</param>
        public override void Create(MigrationBuilder builder)
        {
            builder.CreateTable<StorageCache>(table => table
                .Column(x => x.CacheKey)
                .Column(x => x.ExpiredDate)
                .Column(x => x.Dependency)
                .Column(x => x.CreatedDate)
            );
        }
    }
}