using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Features.CQRS.Commands.Category;
using Bistros.Core.Application.Interfaces;
using MediatR;

namespace Bistros.Core.Application.Features.CQRS.Handlers.Category
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryDto>
    {
        private readonly IRepository<Domain.Entities.Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Domain.Entities.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Domain.Entities.Category
            {
                CategoryId=request.CategoryId,
                CategoryName = request.CategoryName
            };

            await _repository.UpdateAsync(value);
			var result = _mapper.Map<UpdateCategoryDto>(value);

            return result;

		}
    }
}
