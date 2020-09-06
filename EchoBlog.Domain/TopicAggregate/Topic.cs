using EchoBlog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domains.TopicAggregate
{
    /// <summary>
    /// 话题实体类，该实体类为聚合根
    /// </summary>
    public class Topic : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 作者 Id
        /// </summary>
        public long AuthorId { get; private set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; private set; }

        /// <summary>
        /// 分类 Id
        /// </summary>
        public long CategoryId { get; private set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; private set; }

        /// <summary>
        /// 节点 Id
        /// </summary>
        public long NodeId { get; private set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName { get; private set; }

        /// <summary>
        /// 阅读次数
        /// </summary>
        public int ReadTimes { get; private set; }

        public Topic(string title, string content,
            long authorId, string authorName,
            long categoryId, string categoryName,
            long nodeId, string nodeName, int readTimes)
        {
            this.Title = title;
            this.Content = content;
            this.AuthorId = authorId;
            this.AuthorName = authorName;
            this.CategoryId = categoryId;
            this.CategoryName = categoryName;
            this.NodeId = nodeId;
            this.NodeName = nodeName;
            this.ReadTimes = readTimes;

            // 添加话题创建领域事件
            //this.AddDomainEvent(new TopicCreatedDomainEvent(this));
        }
    }
}
