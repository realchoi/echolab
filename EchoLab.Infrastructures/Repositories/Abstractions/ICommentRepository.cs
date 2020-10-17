using System.Collections.Generic;
using System.Threading.Tasks;
using EchoLab.Domains.CommentAggregate;
using EchoLab.Infrastructures.Core;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    public interface ICommentRepository : IRepository<Comment, long>
    {
    }
}