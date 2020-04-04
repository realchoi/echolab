using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domain.Abstractions
{
    /// <summary>
    /// 领域事件处理接口
    /// </summary>
    /// <typeparam name="TDomainEvent"></typeparam>
    public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
    }
}
