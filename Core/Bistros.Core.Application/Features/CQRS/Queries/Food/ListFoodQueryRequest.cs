using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Queries
{
	public class ListFoodQueryRequest :IRequest<List<ResultFoodDto>>
	{
		
	}
}
