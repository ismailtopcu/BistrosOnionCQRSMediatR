using AutoMapper;
using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Application.Features.CQRS.Queries;
using Bistros.Core.Application.Interfaces;
using Bistros.Core.Domain.Entities;
using MediatR;

namespace Bistros.Core.Application.Features.CQRS.Handlers
{
	public class GetFoodQueryHandler : IRequestHandler<GetFoodQueryRequest, ResultFoodDto>
	{
		private readonly IRepository<Food> _repository;
		private readonly IMapper _mapper;

		public GetFoodQueryHandler(IRepository<Food> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<ResultFoodDto> Handle(GetFoodQueryRequest request, CancellationToken cancellationToken)
		{

			var value = await _repository.GetByIdAsync(request.Id);
			return _mapper.Map<ResultFoodDto>(value);
		}
	}
}
