using EchoLab.Domain.Abstractions;
using EchoLab.Domains.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Domains.ArticleAggregate
{
    /// <summary>
    /// 文章实体类，该实体类为聚合根
    /// </summary>
    public class Article : Entity<long>, IAggregateRoot
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
        public int ReadTimes { get; private set; }


        public Article(string authorId, string authorName, string title, string content, int readTimes)
        {
            this.AuthorId = authorId;
            this.AuthorName = authorName;
            this.Title = title;
            this.Content = content;
            this.ReadTimes = readTimes;

            // 添加文章创建领域事件
            this.AddDomainEvent(new ArticleCreatedDomainEvent(this));
        }
    }
}
