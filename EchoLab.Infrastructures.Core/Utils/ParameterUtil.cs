using System;
using System.Linq.Expressions;
using System.Text;

namespace EchoLab.Infrastructures.Core.Utils
{
    public class ParameterUtil
    {
        /// <summary>
        /// 根据传递的参数对象，获取该对象属性的键值对字符串
        /// </summary>
        /// <param name="object">参数对象</param>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <returns></returns>
        public static string GetParameterKeyValue<T>(T @object) where T : new()
        {
            var result = new StringBuilder();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(@object, null);
                if (value == null) continue;
                var key = property.Name;
                result.Append($"&{key}={value}");
            }

            return result.ToString();
        }


        public static Expression<Func<T, bool>> GetExpression<T>(T @object) where T : new()
        {
            Expression<Func<T, bool>> result = model => true;
            return null;
        }
    }
}