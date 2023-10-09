using AutoMapper;
using Bistros.Core.Application.Features.CQRS.Commands;
using Bistros.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bistros.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FoodController(IMediator mediator)
		{
			_mediator = mediator;
			
		}
		[HttpGet]
		public async Task<IActionResult> FoodList()
		{
			var values = await _mediator.Send(new ListFoodQueryRequest());
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateFood(CreateFoodCommandRequest createFoodCommandRequest)
		{
			await _mediator.Send(createFoodCommandRequest);
			return Ok("Başarıyla Eklendi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetFoodById(int id)
		{
			var value = await _mediator.Send(new GetFoodQueryRequest(id));
			return Ok(value);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteFood(int id)
		{
			await _mediator.Send(new RemoveFoodCommandRequest(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateFood(UpdateFoodCommandRequest updateFoodCommandRequest)
		{
			await _mediator.Send(updateFoodCommandRequest);
			return Ok("Başarıyla Güncellendi");
		}
	}
}
