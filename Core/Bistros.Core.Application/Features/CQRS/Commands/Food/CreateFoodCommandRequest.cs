using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Features.CQRS.Commands
{
	public class CreateFoodCommandRequest :IRequest<CreateFoodDto>
	{
		public string FoodName { get; set; }
		public string FoodDescription { get; set; }
		public decimal FoodPrice { get; set; }
		public int CategoryId { get; set; }
	}
}
