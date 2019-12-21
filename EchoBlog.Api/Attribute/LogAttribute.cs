using AspectCore.DynamicProxy;
using EchoBlog.Util.LogUtil;
using System;
using System.Collections.Generic;
using System.Linq;
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
                NLogUtil.Info("方法执行之前。。。");
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                NLogUtil.Info("发生异常。。。");
                throw ex;
            }
            finally
            {
                NLogUtil.Info("方法执行之后。。。");
            }
        }
    }
}
