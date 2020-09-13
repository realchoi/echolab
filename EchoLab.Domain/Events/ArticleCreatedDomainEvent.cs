using EchoLab.Domain.Abstractions;
using EchoLab.Domains.ArticleAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Domains.Events
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
