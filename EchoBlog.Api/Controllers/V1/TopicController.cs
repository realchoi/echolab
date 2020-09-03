using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EchoBlog.Api.Controllers.V1
{
    /// <summary>
    /// 话题接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        IMediator _mediator;

        public TopicController(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
