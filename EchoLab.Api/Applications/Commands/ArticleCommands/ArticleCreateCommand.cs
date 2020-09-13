using EchoLab.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Commands.ArticleCommands
{
    public class ArticleCreateCommand : IRequest<ArticleDto>
    {
        public ArticleCreateCommand() { }

        public ArticleCreateCommand(string authorId, string authorName, string title, string content)
        {
            AuthorId = authorId;
            AuthorName = authorName;
            Title = title;
            Content = content;
        }

        /// <summary>
        /// 作者 Id
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
