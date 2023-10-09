using Bistros.Core.Application.Dtos.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Queries.Category
{
    public class ListCategoryQueryRequest :IRequest<List<ResultCategoryDto>>
    {
    }
}
