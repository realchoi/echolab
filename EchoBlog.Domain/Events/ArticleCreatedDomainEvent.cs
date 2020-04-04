using EchoBlog.Domain.Abstractions;
using EchoBlog.Domains.ArticleAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domains.Events
{
    public class ArticleCreatedDomainEvent : IDomainEvent
    {
        public Article Article { get; private set; }

        public ArticleCreatedDomainEvent(Article article)
        {
            this.Article = article;
        }
    }
}
