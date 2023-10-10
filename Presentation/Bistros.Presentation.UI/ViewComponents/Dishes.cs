using Bistros.Core.Application.Dtos.FoodDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bistros.Presentation.UI.ViewComponents
{
    public class Dishes : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Dishes(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7162/api/Food");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFoodDto>>(jsonData);

                // Verilerden rastgele üç tanesini seçmek için bir Random nesnesi oluşturun
                var random = new Random();

                // Rastgele üç indeks seçin
                var randomIndices = new List<int>();
                while (randomIndices.Count < 3)
                {
                    var randomIndex = random.Next(0, values.Count);
                    if (!randomIndices.Contains(randomIndex))
                    {
                        randomIndices.Add(randomIndex);
                    }
                }

                // Rastgele üç ürünü alın
                var randomProducts = new List<ResultFoodDto>();
                foreach (var index in randomIndices)
                {
                    randomProducts.Add(values[index]);
                }

                return View(randomProducts);
            }
            return View();
        }
    }
}
