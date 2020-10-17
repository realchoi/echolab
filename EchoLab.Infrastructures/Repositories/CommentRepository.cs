using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoLab.Domains.CommentAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EchoLab.Infrastructures.Repositories
{
    public class CommentRepository : Repository<Comment, long, DomainContext>, ICommentRepository
    {
        readonly DomainContext _dbContext;

        public CommentRepository(DomainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}