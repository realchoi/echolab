using EchoLab.Domains.CategoryAggregate;
using EchoLab.Infrastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EchoLab.Infrastructures.Repositories.Abstractions
{
    /// <summary>
    /// 话题分类数据仓储接口
    /// </summary>
    public interface ICategoryRepository : IRepository<Category, long>
    {
        /// <summary>
        /// 查询话题分类列表
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetListAsync();
    }
}
