using Ola.Data.Migrations;
using Ola.Data.Migrations.Builders;
using Ola.Extensions.Categories;

namespace Ola.Extensions.Messages.Notifications
{
    /// <summary>
    /// 通知数据库迁移类。
    /// </summary>
    internal class NotificationDataMigration : CategoryDataMigration<NotificationType>
    {
        /// <summary>
        /// 编辑表格其他属性列。
        /// </summary>
        /// <param name="table">当前表格构建实例对象。</param>
        protected override void Create(CreateTableBuilder<NotificationType> table)
        {
            table.Column(x => x.IconUrl).Column(x => x.Color);
        }

        /// <summary>
        /// 当模型建立时候构建的表格实例。
        /// </summary>
        /// <param name="builder">迁移实例对象。</param>
        public override void Create(MigrationBuilder builder)
        {
            base.Create(builder);
            builder.CreateTable<Notification>(table => table.Column(x => x.Id)
                    .Column(x => x.TypeId)
                    .Column(x => x.UserId)
                    .Column(x => x.Message)
                    .Column(x => x.Status)
                    .Column(x => x.CreatedDate));
        }
    }
}