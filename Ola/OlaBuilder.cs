using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ola
{
    internal class OlaBuilder : IOlaBuilder
    {
        private readonly IServiceCollection _services;

        public OlaBuilder(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            Configuration = configuration;
        }

        /// <summary>
        /// 配置接口。
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 添加服务。
        /// </summary>
        /// <param name="action">配置服务代理类。</param>
        /// <returns>返回构建实例。</returns>
        public IOlaBuilder AddServices(Action<IServiceCollection> action)
        {
            action(_services);
            return this;
        }
    }
}