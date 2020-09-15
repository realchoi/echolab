using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EchoLab.Api.Applications.Queries.NodeQueries;
using EchoLab.Api.Applications.Queries.TopicQueries;
using EchoLab.Api.Dtos;
using EchoLab.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EchoLab.Api.Controllers.V1
{
    /// <summary>
    /// 节点接口
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        readonly IMediator _mediator;

        public NodeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        // 基于角色的授权：角色为 User 的用户才可以访问
        [Authorize(Roles = "User")]
        [HttpPost("getNodes")]
        public async Task<Result<IEnumerable<NodeDto>>> GetNodes([FromBody] NodeQuery query)
        {
            var result = new Result<IEnumerable<NodeDto>>();

            if (string.IsNullOrEmpty(query.CategoryId))
            {
                result.Code = 400;
                result.Message = "参数 categoryId 不能为空";
            }
            else
            {
                try
                {
                    var nodeDto = await _mediator.Send(query);
                    result.Data = nodeDto;
                }
                catch (Exception ex)
                {
                    result.Code = 500;
                    result.Message = $"程序发生异常：{ex.Message}";
                }
            }
            return result;
        }
    }
}