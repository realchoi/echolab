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
            this._dbContext = dbContext;
        }

        /// <summary>
        /// 根据话题 ID 获取评论集合
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        public async Task<List<Comment>> GetListByTopicId(long topicId)
        {
            return await _dbContext.Comments.Where(p => p.TopicId == topicId).ToListAsync();
        }


        /// <summary>
        /// 根据作者 ID 获取评论集合
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public async Task<List<Comment>> GetListByAuthorId(long authorId)
        {
            return await _dbContext.Comments.Where(p => p.AuthorId == authorId).ToListAsync();
        }
    }
}