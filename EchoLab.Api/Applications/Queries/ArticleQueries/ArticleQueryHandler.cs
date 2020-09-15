using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.ArticleAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.ArticleQueries
{
    public class ArticleQueryHandler : IRequestHandler<ArticleQuery, IEnumerable<ArticleDto>>
    {
        IArticleRepository _articleRepository;
        IMapper _mapper;

        public ArticleQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(ArticleQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Article, bool>> expression = article =>
                (string.IsNullOrEmpty(request.AuthorId) || article.AuthorId == request.AuthorId) &&
                (string.IsNullOrEmpty(request.NodeId) || article.NodeId == request.NodeId);

            // var articles = await _articleRepository.GetByAuthorIdAsync(request.AuthorId);
            var articles = await _articleRepository.GetListAsync(expression);
            var articlesDto = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articles);
            return articlesDto;
        }
    }
}