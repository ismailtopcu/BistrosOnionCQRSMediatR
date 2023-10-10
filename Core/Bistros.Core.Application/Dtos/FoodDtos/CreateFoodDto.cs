using Bistros.Core.Domain.Entities;

namespace Bistros.Core.Application.Dtos.FoodDtos
{
    public class CreateFoodDto
    {
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
		public decimal FoodPrice { get; set; }
		public int CategoryId { get; set; }
    }
}
