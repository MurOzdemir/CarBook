﻿using Carbook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("https://localhost:7172/api/Services");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);

            }
            return View();
        }

    }
}
