using AutoMapper;
using Bistros.Core.Application.Dtos.CategoryDtos;
using Bistros.Core.Application.Features.CQRS.Commands.Category;
using Bistros.Core.Application.Features.CQRS.Queries.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Bistros.Presentation.UI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

		public AdminCategoryController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _mediator.Send(new ListCategoryQueryRequest());
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            await _mediator.Send(createCategoryCommandRequest);
            return RedirectToAction("CategoryList");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _mediator.Send(new GetCategoryQueryRequest(id));
            var result = _mapper.Map<UpdateCategoryDto>(values);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var value = await _mediator.Send(updateCategoryCommandRequest);
            return RedirectToAction("CategoryList");
        } 
        
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommandRequest(id));
			return RedirectToAction("CategoryList");
		}
        
    }
}
