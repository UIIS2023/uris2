using System;
using AuctionService.DtoModels;
using Newtonsoft.Json;

namespace AuctionService.ServiceCalls
{
	public class OvlascenoLiceService : IOvlascenoLiceService
	{
        /// <summary>
        /// Iconfig
        /// </summary>
        private readonly IConfiguration Configuration;
        /// <summary>
        /// DI za konfiguraciju
        /// </summary>
        public OvlascenoLiceService(IConfiguration Configuration)
		{
            this.Configuration = Configuration;
		}

        /// <summary>
        /// Metoda za komunikaciju sa ovlascenim licem
        /// </summary>
        public async Task<OvlascenoLiceDto> getOvlascenoLice(Guid ovlascenoLice)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{Configuration["Services:Ovlasceno_lice"]}api/ovlascenaLica/{ovlascenoLice}");

                HttpContent content = new StringContent(JsonConvert.SerializeObject(ovlascenoLice));
                content.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                var k = JsonConvert.DeserializeObject<OvlascenoLiceDto>(responseContent);

                return k;
            }
        }
    }
}

