namespace Bistros.Core.Domain.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public decimal FoodPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
