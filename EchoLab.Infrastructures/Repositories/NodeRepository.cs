using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EchoLab.Domains.NodeAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EchoLab.Infrastructures.Repositories
{
    /// <summary>
    /// 节点分类数据仓储类
    /// </summary>
    public class NodeRepository : Repository<Node, long, DomainContext>, INodeRepository
    {
        readonly DomainContext _dbContext;

        public NodeRepository(DomainContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}