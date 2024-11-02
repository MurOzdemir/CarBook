using Carbook.Dto.FooterAddressDtos;
using Carbook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAdressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("https://localhost:7172/api/FooterAddresses");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
