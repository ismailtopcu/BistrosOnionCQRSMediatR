using AutoMapper;
using Bistros.Core.Application.Features.CQRS.Commands.Category;
using Bistros.Core.Application.Features.CQRS.Queries.Category;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bistros.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public CategoryController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _mediator.Send(new ListCategoryQueryRequest());
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
		{
			await _mediator.Send(createCategoryCommandRequest);
			return Ok("Başarıyla Eklendi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategoryById(int id)
		{
			var value = await _mediator.Send(new GetCategoryQueryRequest(id));
			return Ok(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _mediator.Send(new RemoveCategoryCommandRequest(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
		{
			await _mediator.Send(updateCategoryCommandRequest);
			return Ok("Başarıyla Güncellendi");
		}
	}
}
