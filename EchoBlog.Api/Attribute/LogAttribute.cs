using AspectCore.DynamicProxy;
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
                Console.WriteLine("方法执行之前。。。");
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常。。。");
                throw ex;
            }
            finally
            {
                Console.WriteLine("方法执行之后。。。");
            }
        }
    }
}
