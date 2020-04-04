using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Domain.Abstractions
{
    /// <summary>
    /// 领域事件接口
    /// </summary>
    public interface IDomainEvent : INotification
    {
    }
}
