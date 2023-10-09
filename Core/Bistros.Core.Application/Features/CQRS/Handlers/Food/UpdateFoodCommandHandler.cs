using AutoMapper;
using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Application.Features.CQRS.Commands;
using Bistros.Core.Application.Interfaces;
using Bistros.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Handlers
{
	public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommandRequest, UpdateFoodDto>
	{
		private readonly IRepository<Food> _repository;
		private readonly IMapper _mapper;

		public UpdateFoodCommandHandler(IRepository<Food> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<UpdateFoodDto> Handle(UpdateFoodCommandRequest request, CancellationToken cancellationToken)
		{
			var value = new Food
			{
				FoodDescription = request.FoodDescription,
				FoodId = request.FoodId,
				CategoryId = request.CategoryId,
				FoodName = request.FoodName,
				FoodPrice=request.FoodPrice
			};
			await _repository.UpdateAsync(value);
			var result = _mapper.Map<UpdateFoodDto>(value);
			return result;

		}
	}
}
