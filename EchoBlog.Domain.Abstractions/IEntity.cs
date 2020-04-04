using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domain.Abstractions
{
    /// <summary>
    /// 公共实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取实体的主键
        /// </summary>
        /// <returns></returns>
        object[] GetKeys();

        /// <summary>
        /// 创建时间
        /// </summary>
        long CreateTime { get; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        long LastTime { get; }
    }


    /// <summary>
    /// 公共实体接口，同时指定实体的主键类型
    /// </summary>
    /// <typeparam name="TKey">实体的主键类型</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        /// <summary>
        /// 实体的主键
        /// </summary>
        TKey Id { get; }
    }
}
