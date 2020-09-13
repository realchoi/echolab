using EchoLab.Domain.Abstractions;
using EchoLab.Domains.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.DomainEventHandlers
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
