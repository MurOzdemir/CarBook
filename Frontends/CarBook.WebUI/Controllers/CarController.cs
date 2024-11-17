using Carbook.Dto.CarDtos;
using Carbook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Galerimiz";
            ViewBag.v2 = "Araçlarımız";     
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("https://localhost:7172/api/Cars/GetCarWithBrand");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
