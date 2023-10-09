using Bistros.Core.Application.Dtos.FoodDtos;

namespace Bistros.Core.Application.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public  List<ResultFoodDto>? Foods {get; set;} 
    }
}
