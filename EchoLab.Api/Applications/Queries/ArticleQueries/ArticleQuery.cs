using EchoLab.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.ArticleQueries
{
    public class ArticleQuery : IRequest<IEnumerable<ArticleDto>>
    {
        public string AuthorId { get; /*private*/ set; }
        public string NodeId { get; /*private*/ set; }

        public ArticleQuery() { }

        public ArticleQuery(string authorId) => AuthorId = authorId;
    }
}
