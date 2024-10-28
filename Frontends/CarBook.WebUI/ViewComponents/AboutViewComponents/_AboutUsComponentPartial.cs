using Carbook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial:ViewComponent
    {
        //  API consume etmek siteden gelen verileri tüketmek ayaga kaldırmak 
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7172/api/Abouts");
            if (responseMessage.IsSuccessStatusCode) 
            {
                var jsondata= await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
                return View(values);
            }
            return View();
            // kurumsal kimligimizle 25 yıllık sektör tecrübemizi sizler için en güvenilir en konforlu  taşımacılık ve araç  kiralama  sistemini kurduk. Carbook firması  olarak alanında oldukça hatlarrımız personellerimiz sizlere 7/24 hem telefon hemde  online hatlarımız üzerinden hizmet vermektedir. saatlik, haftalık, günlük  ve aylık opsiyonlarla olabildigince uygun  fiyatlarla alanının en iyi araclarını sizlere sunuyoruz.Müşteri memnunyetini esas aldıgımız Carbook firmamız  29'den fazla  şübesiyle Türkiye'de hizmete Devam ederken önümüzdeki yıl itibariyle Almanya, İsviçre ve İtalya'da 3 ayrı şubemizle global pazarda sizleri karşılayama devam edecek sorularınız ve önerileriniz için iletişim kanallarımızdan bizlere ulaşabilirsiniz.
        }
    }
}
