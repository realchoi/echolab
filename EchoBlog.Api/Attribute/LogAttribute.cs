using AspectCore.DynamicProxy;
using EchoBlog.Infrastructures.Core.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EchoBlog.Api.Attribute
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public class LogAttribute : AbstractInterceptorAttribute
    {
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                LogUtil.Info("方法执行之前。。。");
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                LogUtil.Info("发生异常。。。");
                throw ex;
            }
            finally
            {
                LogUtil.Info("方法执行之后。。。");
            }
        }
    }
}
