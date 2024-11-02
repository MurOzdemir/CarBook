using Carbook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient(); // client olursturup  client nesnesine atar.
            createContactDto.SendDate = DateTime.Now;   // gönderme nesnenin tarihini bugünün tarihi yapsın
            var jsonData= JsonConvert.SerializeObject(createContactDto);    //parametreden gelen değeri serilize etmesi gerekir.
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7172/api/Contacts",stringContent); // adress kaydetmek için postanync kullanılır. birde benden data bekliyor stringcontact bekliyor
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "default");
            }
            return View();
        }

    }
}
