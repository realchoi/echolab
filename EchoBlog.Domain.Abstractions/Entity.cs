using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domain.Abstractions
{
    /// <summary>
    /// 公共实体类
    /// </summary>
    public abstract class Entity : IEntity
    {
        public virtual int CreateTime { get; protected set; }

        public virtual int LastTime { get; protected set; }

        /// <summary>
        /// 获取实体的主键
        /// </summary>
        /// <returns></returns>
        public abstract object[] GetKeys();

        /// <summary>
        /// 将实体对象转换为字符串，该字符串包含该实体对象的类型和主键
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[Entity: {this.GetType().Name}], Keys = {string.Join(", ", this.GetKeys())}";
        }
    }


    /// <summary>
    /// 公共实体类，同时指定实体的主键类型
    /// </summary>
    /// <typeparam name="TKey">实体的主键类型</typeparam>
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        int? _requestedHashCode;

        /// <summary>
        /// 实体的主键
        /// </summary>
        public virtual TKey Id { get; protected set; }

        /// <summary>
        /// 获取实体的主键
        /// </summary>
        /// <returns></returns>
        public override object[] GetKeys()
        {
            return new object[] { this.Id };
        }

        /// <summary>
        /// 将实体对象转换为字符串，该字符串包含该实体对象的类型和主键
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[Entity: {this.GetType().Name}] Id = {this.Id}";
        }

        /// <summary>
        /// 判断两个实体对象是否相等
        /// </summary>
        /// <param name="obj">待比较的实体对象</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TKey>))
                return false;

            if (this.GetType() != obj.GetType())
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            Entity<TKey> temp = (Entity<TKey>)obj;
            if (temp.IsTransient() || this.IsTransient())
                return false;
            else
                return temp.Id.Equals(this.Id);
        }

        /// <summary>
        /// 获取实体对象的哈希值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        /// <summary>
        /// 判断实体对象是否是全新创建的、未持久化的
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(this.Id, default);
        }

        /// <summary>
        /// 判断两个实体对象是否相等
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            if (object.Equals(left, null))
                return object.Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        /// <summary>
        /// 判断两个实体对象是否不相等
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
    }
}
