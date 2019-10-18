using Microsoft.Extensions.Hosting;

namespace Ola
{
    /// <summary>
    /// 后台服务基类。
    /// </summary>
    public abstract class HostedService : BackgroundService, IServices
    {
    }
}