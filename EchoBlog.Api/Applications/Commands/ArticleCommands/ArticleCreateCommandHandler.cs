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

namespace EchoBlog.Api.Applications.Commands.ArticleCommands
{
    public class ArticleCreateCommandHandler : IRequestHandler<ArticleCreateCommand, ArticleDto>
    {
        IArticleRepository _articleRepository;
        IMapper _mapper;

        public ArticleCreateCommandHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }


        public async Task<ArticleDto> Handle(ArticleCreateCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.AddAsync(_mapper.Map<ArticleCreateCommand, Article>(request));
            await _articleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return _mapper.Map<Article, ArticleDto>(article);
        }
    }
}
