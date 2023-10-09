using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Features.CQRS.Commands.Category;
using Bistros.Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Handlers.Category
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryDto>
    {
        private readonly IRepository<Domain.Entities.Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Domain.Entities.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryDto> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Category
            {
                CategoryName = request.CategoryName
            };
            await _repository.CreateAsync(value);
            var result = _mapper.Map<CreateCategoryDto>(value);
            return result;
        }
    }
}
