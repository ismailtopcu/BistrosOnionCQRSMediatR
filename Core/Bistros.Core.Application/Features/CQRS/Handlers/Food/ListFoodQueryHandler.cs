using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Application.Features.CQRS.Queries;
using Bistros.Core.Application.Interfaces;
using Bistros.Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Handlers
{
	public class ListFoodQueryHandler : IRequestHandler<ListFoodQueryRequest, List<ResultFoodDto>>
	{
		private readonly IRepository<Food> _repository;
		private readonly IMapper _mapper;
		public ListFoodQueryHandler(IRepository<Food> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<ResultFoodDto>> Handle(ListFoodQueryRequest request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllIncluding(food => food.Category).ToListAsync();
			return _mapper.Map<List<ResultFoodDto>>(values);
			//var values = await _repository.GetAllAsync();
			//return _mapper.Map<List<ResultFoodDto>>(values);
		}
	}
}
