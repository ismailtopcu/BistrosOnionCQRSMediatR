using Bistros.Core.Application.Dtos.CategoryDtos;
using MediatR;

namespace Bistros.Core.Application.Features.CQRS.Commands.Category
{
    public class UpdateCategoryCommandRequest :IRequest<UpdateCategoryDto> 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
