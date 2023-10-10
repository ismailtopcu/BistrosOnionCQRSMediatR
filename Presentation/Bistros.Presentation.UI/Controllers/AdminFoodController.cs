using Bistros.Core.Application.Dtos.FoodDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Bistros.Presentation.UI.Controllers
{
	public class AdminFoodController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminFoodController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> FoodList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7162/api/Food");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFoodDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateFood()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateFood(CreateFoodDto createFoodDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFoodDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7162/api/Food", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("FoodList");
			}
			return View(createFoodDto);
		}
		[HttpGet]
		public async Task<IActionResult> UpdateFood(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7162/api/Food/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFoodDto>(jsonData);
				return View(values);
			}
			return RedirectToAction("FoodList");
		}
		[HttpPost]
		public async Task<IActionResult> UpdateFood(UpdateFoodDto updateFoodDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFoodDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7162/api/Food", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("FoodList");
			}
			return View();
		}

		public async Task<IActionResult> DeleteFood(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7162/api/Food?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("FoodList");
			}
			return View();
		}
	}
}
