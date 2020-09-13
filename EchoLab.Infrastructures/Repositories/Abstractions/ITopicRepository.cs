using EchoLab.Domains.TopicAggregate;
using EchoLab.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    /// <summary>
    /// 话题数据仓储接口
    /// </summary>
    public interface ITopicRepository : IRepository<Topic, long>
    {
        /// <summary>
        /// 根据分类 Id 查询话题列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<List<Topic>> GetListByCategoryIdAsync(long categoryId);


        /// <summary>
        /// 根据节点 Id 查询话题列表
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<List<Topic>> GetListByNodeIdAsync(long nodeId);


        /// <summary>
        /// 根据作者 Id 查询话题列表
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Task<List<Topic>> GetListByAuthorIdAsync(long authorId);
    }
}
