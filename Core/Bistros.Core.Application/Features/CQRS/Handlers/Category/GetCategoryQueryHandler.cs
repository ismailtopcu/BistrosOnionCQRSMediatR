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
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, ResultCategoryDto>
    {
        private readonly IRepository<Domain.Entities.Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Domain.Entities.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultCategoryDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ResultCategoryDto>(value);
        }
    }
}
