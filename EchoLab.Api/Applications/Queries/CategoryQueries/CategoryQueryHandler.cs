using AutoMapper;
using EchoLab.Api.Dtos;
using EchoLab.Domains.CategoryAggregate;
using EchoLab.Infrastructures.Repositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EchoLab.Api.Applications.Queries.CategoryQueries
{
    public class CategoryQueryHandler : IRequestHandler<CategoryQuery, IEnumerable<CategoryDto>>
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(CategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetListAsync();
            var categoryDtoList = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categoryList);
            return categoryDtoList;
        }
    }
}
