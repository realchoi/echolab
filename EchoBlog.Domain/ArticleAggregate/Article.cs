using EchoBlog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domains.ArticleAggregate
{
    /// <summary>
    /// 文章实体类，该实体类为聚合根
    /// </summary>
    public class Article : Entity<int>, IAggregateRoot
    {
        /// <summary>
        /// 作者 Id
        /// </summary>
        public string AuthorId { get; private set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; private set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public string ReadTimes { get; private set; }
    }
}
