using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Domain.Entities;
using MediatR;

namespace Bistros.Core.Application.Features.CQRS.Queries
{
	public class GetFoodQueryRequest : IRequest<ResultFoodDto>
	{
		public GetFoodQueryRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
