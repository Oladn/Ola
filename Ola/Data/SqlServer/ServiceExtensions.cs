using System;
using Microsoft.Extensions.DependencyInjection;
using Ola.Data.Internal;
using Ola.Data.Migrations;
using Ola.Data.Migrations.Models;
using Ola.Data.Query;
using Ola.Data.Query.Translators;
using Ola.Data.SqlServer.Migrations;
using Ola.Data.SqlServer.Query;
using Ola.Data.SqlServer.Query.Translators;

namespace Ola.Data.SqlServer
{
    /// <summary>
    /// 数据库相关的服务器扩展。
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// 添加SQLServer数据库服务。
        /// </summary>
        /// <param name="builder">服务集合。</param>
        /// <returns>返回服务集合实例。</returns>
        public static IOlaBuilder UseSqlServer(this IOlaBuilder builder)
        {
            return builder.UseSqlServer(options =>
            {
                var section = builder.Configuration.GetSection("Data");
                foreach (var current in section.GetChildren())
                {
                    switch (current.Key.ToLower())
                    {
                        case "name":
                            options.ConnectionString = $"Data Source=.;Initial Catalog={current.Value};Integrated Security=True;";
                            break;
                        case "connectionstring":
                            options.ConnectionString = current.Value;
                            break;
                        case "prefix":
                            options.Prefix = current.Value;
                            break;
                        default:
                            options[current.Key] = current.Value;
                            break;
                    }
                }
            });
        }

        /// <summary>
        /// 添加SQLServer数据库服务。
        /// </summary>
        /// <param name="builder">构建服务实例。</param>
        /// <param name="options">数据源选项。</param>
        /// <returns>返回服务集合实例。</returns>
        public static IOlaBuilder UseSqlServer(this IOlaBuilder builder, Action<DatabaseOptions> options)
        {
            Check.NotNull(builder, nameof(builder));
            Check.NotNull(options, nameof(options));
            var source = new DatabaseOptions();
            options(source);

            return builder.AddServices(services => services
                    .AddSingleton<IDatabase, SqlServerDatabase>()
                    .Configure<DatabaseOptions>(o =>
                    {
                        o.ConnectionString = source.ConnectionString;
                        o.Prefix = source.Prefix?.Trim();
                        o.Provider = "SqlServer";
                    })
                    .AddSingleton(typeof(IDbContext<>), typeof(DbContext<>))
                    .AddTransient<IDataMigrator, DataMigrator>()
                    .AddTransient<IMigrationRepository, SqlServerMigrationRepository>()
                    .AddTransient<IMigrationsSqlGenerator, SqlServerMigrationsSqlGenerator>()
                    .AddSingleton<IQuerySqlGenerator, SqlServerQuerySqlGenerator>()
                    .AddSingleton<ITypeMapper, SqlServerTypeMapper>()
                    .AddSingleton<ISqlHelper, SqlServerHelper>()
                    .AddSingleton<IMemberTranslator, SqlServerCompositeMemberTranslator>()
                    .AddSingleton<IMethodCallTranslator, SqlServerCompositeMethodCallTranslator>()
                    .AddSingleton<IExpressionFragmentTranslator, SqlServerCompositeExpressionFragmentTranslator>()
                    .AddSingleton<IExpressionVisitorFactory, SqlServerExpressionVisitorFactory>());
        }
    }
}