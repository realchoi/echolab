using EchoBlog.Api.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBlog.Api.Applications.Queries.CategoryQueries
{
    public class CategoryQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
