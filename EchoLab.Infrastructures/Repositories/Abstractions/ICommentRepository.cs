using System.Collections.Generic;
using System.Threading.Tasks;
using EchoLab.Domains.CommentAggregate;
using EchoLab.Infrastructures.Core;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    public interface ICommentRepository : IRepository<Comment, long>
    {
        /// <summary>
        /// 根据话题 ID 获取评论集合
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        Task<List<Comment>> GetListByTopicId(long topicId);

        /// <summary>
        /// 根据作者 ID 获取评论集合
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Task<List<Comment>> GetListByAuthorId(long authorId);
    }
}