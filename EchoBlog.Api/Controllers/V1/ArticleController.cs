using EchoBlog.Api.Applications.Commands;
using EchoBlog.Api.Applications.Queries;
using EchoBlog.Api.Dtos;
using EchoBlog.Infrastructures.Core.Utils;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EchoBlog.Api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
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
        [HttpPost("list")]
        //[Log]
        public async Task<IEnumerable<ArticleDto>> Get([FromBody] ArticleQuery articleQuery)
        {
            LogUtil.Info("Get 方法执行");
            return await _mediator.Send(articleQuery);
        }

        [HttpPost("create")]
        public async Task<ArticleDto> Create([FromBody] ArticleCreateCommand articleCreateCommand)
        {
            LogUtil.Info("文章创建");
            return await _mediator.Send(articleCreateCommand, HttpContext.RequestAborted);
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
