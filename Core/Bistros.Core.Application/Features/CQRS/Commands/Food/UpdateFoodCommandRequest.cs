using Bistros.Core.Application.Dtos.FoodDtos;
using MediatR;

namespace Bistros.Core.Application.Features.CQRS.Commands
{
	public class UpdateFoodCommandRequest :IRequest<UpdateFoodDto>
	{
		public int FoodId { get; set; }
		public string FoodName { get; set; }
		public string FoodDescription { get; set; }
		public decimal FoodPrice { get; set; }
		public int CategoryId { get; set; }
	}
}
