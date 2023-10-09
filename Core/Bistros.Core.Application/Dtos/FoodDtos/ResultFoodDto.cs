using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Dtos.FoodDtos
{
    public class ResultFoodDto
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
		public decimal FoodPrice { get; set; }
		public Category Category{ get; set; }
    }
}
