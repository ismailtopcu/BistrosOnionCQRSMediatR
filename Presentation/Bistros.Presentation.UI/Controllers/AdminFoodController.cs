using AutoMapper;
using Bistros.Core.Application.Features.CQRS.Commands;
using Bistros.Core.Application.Features.CQRS.Queries;
using Bistros.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bistros.Presentation.UI.Controllers
{
	public class AdminFoodController : Controller
	{
		private readonly IMediator _mediator;
		

		public AdminFoodController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> FoodList()
		{
			var values = await _mediator.Send(new ListFoodQueryRequest());
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateFood()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateFood(CreateFoodCommandRequest request)
		{
			await _mediator.Send(request);
			return RedirectToAction("Foodlist");
		}
	}
}
