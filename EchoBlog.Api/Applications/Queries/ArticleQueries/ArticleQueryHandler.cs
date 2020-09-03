using AutoMapper;
using EchoBlog.Api.Dtos;
using EchoBlog.Domains.ArticleAggregate;
using EchoBlog.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Queries.ArticleQueries
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
            var articles = await _articleRepository.GetByAuthorIdAsync(request.AuthorId);
            var articlesDto = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDto>>(articles);
            return articlesDto;
        }
    }
}
