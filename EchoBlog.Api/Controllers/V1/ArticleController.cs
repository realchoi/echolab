using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoBlog.Model;
using EchoBlog.Service.Def;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EchoBlog.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET: api/Article
        // 基于角色的授权：角色为 Admin 的用户才可以访问
        [Authorize(Roles = "Admin")]

        // 基于策略的授权：角色为 Admin 或者为 User 的用户都可以访问
        // [Authorize(Policy = "AdminOrUser")]

        // 基于策略的授权：角色为 Admin 且为 User 的用户才可以访问
        // [Authorize(Policy = "AdminAndUser")]

        // 使用自定义授权策略
        // [Authorize(Policy = "RequirementPolicy")]
        [HttpGet]
        public async Task<IEnumerable<ArticleModel>> Get()
        {
            try
            {
                var articles = await articleService.GetAllArticles();
                return articles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/Article/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Article
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
