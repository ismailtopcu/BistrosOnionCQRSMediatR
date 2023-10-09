using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Features.CQRS.Queries.Category;
using Bistros.Core.Application.Interfaces;
using Bistros.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Handlers.Category
{
    public class ListCategoryQueryHandler : IRequestHandler<ListCategoryQueryRequest, List<ResultCategoryDto>>
    {
        private readonly IRepository<Domain.Entities.Category> _repository;
        private readonly IMapper _mapper;

        public ListCategoryQueryHandler(IRepository<Domain.Entities.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultCategoryDto>> Handle(ListCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            List<ResultCategoryDto> result = new ();

            foreach (var value in values)
            {
               result.Add( new ResultCategoryDto()
                {
                    CategoryId = value.CategoryId,
                    CategoryName = value.CategoryName
                });
            }

            return result;

            //return _mapper.Map<IList<ResultCategoryDto>>(values);
        }
    }
}
