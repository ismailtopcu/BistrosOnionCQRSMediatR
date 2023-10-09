using Bistros.Core.Application.Dtos.FoodDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Queries.Food
{
	public class ListFoodWithCategoryQueryRequest :IRequest<List<ResultFoodDto>>
	{
		
	}
}
