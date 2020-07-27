using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures.Core.CommonModels
{
    /// <summary>
    /// Dto 基类
    /// </summary>
    /// <typeparam name="TKey">主键的类型</typeparam>
    public abstract class BaseDto<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual TKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual long CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual long LastTime { get; set; }
    }
}
