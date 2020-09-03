using EchoBlog.Domains.TopicAggregate;
using EchoBlog.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Infrastructures.Repositories.Abstractions
{
    public interface ITopicRepository : IRepository<Topic, long>
    {
        /// <summary>
        /// 根据分类 Id 查询话题列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<List<Topic>> GetListByCategoryIdAsync(string categoryId);


        /// <summary>
        /// 根据节点 Id 查询话题列表
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<List<Topic>> GetListByNodeIdAsync(string nodeId);


        /// <summary>
        /// 根据作者 Id 查询话题列表
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Task<List<Topic>> GetListByAuthorIdAsync(string authorId);
    }
}
