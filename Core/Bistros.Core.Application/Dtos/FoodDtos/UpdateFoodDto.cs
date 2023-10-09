namespace Bistros.Core.Application.Dtos.FoodDtos
{
    public class UpdateFoodDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
		public decimal FoodPrice { get; set; }
		public int CategoryId { get; set; }
    }
}
