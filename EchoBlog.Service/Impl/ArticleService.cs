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
        private readonly IArticleRepository articleReposity;

        private readonly IMapper mapper;

        public ArticleService(IArticleRepository articleReposity, IMapper mapper)
        {
            this.articleReposity = articleReposity;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ArticleModel>> GetAllArticles()
        {
            var articles = await articleReposity.GetAllArticles();

            var articleModels = mapper.Map<List<ArticleEntity>, List<ArticleModel>>(articles.ToList());

            return articleModels;
        }
    }
}
