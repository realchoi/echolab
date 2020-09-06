using EchoBlog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domains.CategoryAggregate
{
    /// <summary>
    /// 话题分类实体类，该实体类为聚合根
    /// </summary>
    public class Category : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

        public Category(string code, string name, string description)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;

            // 添加话题分类创建领域事件
            //this.AddDomainEvent(new TopicCreatedDomainEvent(this));
        }
    }
}
