using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EchoBlog.Domain.Abstractions
{
    /// <summary>
    /// 值对象
    /// </summary>
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if ((left is null) ^ (right is null))
                return false;

            return left is null || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        /// <summary>
        /// 获取值对象的原子值
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetAutomicValues();

        /// <summary>
        /// 判断两个值对象是否相等
        /// </summary>
        /// <param name="obj">待比较的值对象</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = this.GetAutomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAutomicValues().GetEnumerator();
            // 遍历值对象的原子值，比较原子值是否相等
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if ((thisValues.Current is null) ^ (otherValues.Current is null))
                    return false;
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                    return false;
            }
            // 确保原子值全部遍历完
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        /// <summary>
        /// 获取值对象的哈希值，该哈希值通过值对象的各个原子值的哈希值进行异或运算后得到
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.GetAutomicValues()
                .Select(s => s != null ? s.GetHashCode() : 0)
                .Aggregate((a, b) => a ^ b);
        }
    }
}
