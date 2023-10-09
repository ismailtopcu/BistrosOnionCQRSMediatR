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
	public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommandRequest, CreateFoodDto>
	{
		private readonly IRepository<Food> _repository;
		private readonly IMapper _mapper;

		public CreateFoodCommandHandler(IRepository<Food> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<CreateFoodDto> Handle(CreateFoodCommandRequest request, CancellationToken cancellationToken)
		{
			var value = new Food
			{
				CategoryId = request.CategoryId,
				FoodName = request.FoodName,
				FoodDescription = request.FoodDescription,
				FoodPrice = request.FoodPrice
			};
			await _repository.CreateAsync(value);
			var result = _mapper.Map<CreateFoodDto>(value);
			return result;
		}
	}
}
