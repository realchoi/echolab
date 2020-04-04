using EchoBlog.Domain.Abstractions;
using EchoBlog.Domains.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.DomainEventHandlers
{
    public class ArticleCreatedDomainEventHandler : IDomainEventHandler<ArticleCreatedDomainEvent>
    {
        public Task Handle(ArticleCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            // 暂不实现
            return Task.CompletedTask;
        }
    }
}
