using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Dtos.FoodDtos;
using Bistros.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Mapping
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultCategoryDto,Category>().ReverseMap();
            CreateMap<CreateCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,ResultCategoryDto>().ReverseMap();

            CreateMap<ResultFoodDto, Food>().ReverseMap();
            CreateMap<CreateFoodDto, Food>().ReverseMap();
            CreateMap<UpdateFoodDto, Food>().ReverseMap();
        }
    }
}
