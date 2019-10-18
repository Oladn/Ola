﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ola.Extensions;
using Ola.Mvc;

namespace Ola.Apis
{
    /// <summary>
    /// 控制器基类。
    /// </summary>
    [Route("open/{controller}")]
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// 成功。
        /// </summary>
        protected ApiResult Succeeded() => ApiResult.Succeeded;

        /// <summary>
        /// 失败。
        /// </summary>
        protected ApiResult Failured() => ApiResult.Failured;

        /// <summary>
        /// 未知错误。
        /// </summary>
        protected ApiResult UnknownError() => ApiResult.UnknownError;

        /// <summary>
        /// 返回错误代码。
        /// </summary>
        /// <param name="code">错误码。</param>
        /// <returns>返回API结果。</returns>
        protected ApiResult Error(ErrorCode code) => new ApiResult(code);

        /// <summary>
        /// 返回错误代码。
        /// </summary>
        /// <param name="code">错误码。</param>
        /// <param name="msg">错误信息。</param>
        /// <returns>返回API结果。</returns>
        protected ApiResult Error(ErrorCode code, string msg) => new ApiResult(code, msg);

        /// <summary>
        /// 空参数。
        /// </summary>
        /// <param name="name">参数名称。</param>
        /// <returns>返回API结果。</returns>
        protected ApiResult NullParameter(string name) => new ApiResult(ErrorCode.NullParameter).Format(name);

        /// <summary>
        /// 参数错误。
        /// </summary>
        /// <param name="name">参数名称。</param>
        /// <returns>返回API结果。</returns>
        protected ApiResult InvalidParameter(string name) => new ApiResult(ErrorCode.InvalidParameter).Format(name);

        /// <summary>
        /// 数据实例对象。
        /// </summary>
        /// <param name="data">数据实例对象。</param>
        /// <returns>返回数据实例对象。</returns>
        protected ApiDataResult Data(object data) => new ApiDataResult(data);

        /// <summary>
        /// 未找到相关信息。
        /// </summary>
        /// <param name="name">信息名称。</param>
        /// <returns>返回API结果。</returns>
        protected ApiResult NotFound(string name) => new ApiResult(ErrorCode.NotFound, name);

        private Version _version;
        /// <summary>
        /// 当前程序的版本。
        /// </summary>
        protected Version Version => _version ??= Cores.Version;

        private ILocalizer _localizer;
        /// <summary>
        /// 本地化接口。
        /// </summary>
        protected ILocalizer Localizer => _localizer ??= GetRequiredService<ILocalizer>();

        private ILogger _logger;
        /// <summary>
        /// 日志接口。
        /// </summary>
        protected virtual ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = HttpContext.RequestServices.GetRequiredService<ILoggerFactory>()
                        .CreateLogger(GetType());
                }
                return _logger;
            }
        }

        /// <summary>
        /// 获取注册的服务对象。
        /// </summary>
        /// <typeparam name="TService">服务类型或者接口。</typeparam>
        /// <returns>返回当前服务的实例对象。</returns>
        protected TService GetService<TService>()
        {
            return HttpContext.RequestServices.GetService<TService>();
        }

        /// <summary>
        /// 获取已经注册的服务对象。
        /// </summary>
        /// <typeparam name="TService">服务类型或者接口。</typeparam>
        /// <returns>返回当前服务的实例对象。</returns>
        protected TService GetRequiredService<TService>()
        {
            return HttpContext.RequestServices.GetRequiredService<TService>();
        }

        private ISettingDictionaryManager _settingDictionaryManager;
        /// <summary>
        /// 获取字典值。
        /// </summary>
        /// <param name="path">标识。</param>
        /// <returns>返回字典值。</returns>
        protected string GetDictionaryValue(string path) =>
            (_settingDictionaryManager ??= GetRequiredService<ISettingDictionaryManager>())
            .GetOrAddSettings(path);

        private CacheApplication _application;

        /// <summary>
        /// 当前应用程序实例，只有在使用<seealso cref="ApplicationAuthorizeAttribute"/>修饰才可使用当前属性。
        /// </summary>
        protected CacheApplication Application
        {
            get
            {
                if (_application == null)
                {
                    _application = HttpContext.Items[typeof(CacheApplication)] as CacheApplication;
                    if(_application == null)
                        throw new Exception("");
                }

                return _application;
            }
        }
    }
}