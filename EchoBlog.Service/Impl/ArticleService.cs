using AutoMapper;
using EchoBlog.Entity;
using EchoBlog.Model;
using EchoBlog.Repository.Def;
using EchoBlog.Service.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoBlog.Service.Impl
{
    /// <summary>
    /// 文章业务服务类
    /// </summary>
    public class ArticleService : IArticleService
    {
        /// <summary>
        /// 文章数据服务对象
        /// </summary>
        private readonly IArticleRepository articleReposity;

        /// <summary>
        /// AutoMapper 映射对象
        /// </summary>
        private readonly IMapper mapper;

        public ArticleService(IArticleRepository articleReposity, IMapper mapper)
        {
            this.articleReposity = articleReposity;
            this.mapper = mapper;
        }

        /// <summary>
        /// 获取所有的文章
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ArticleModel>> GetAllArticles()
        {
            var articles = await articleReposity.GetAllArticles();

            var articleModels = mapper.Map<IEnumerable<ArticleEntity>, IEnumerable<ArticleModel>>(articles.ToList());

            return articleModels;
        }
    }
}
