using System;
using AuctionService.DtoModels;
using Newtonsoft.Json;

namespace AuctionService.ServiceCalls
{
    /// <summary>
    /// Klasa parcela
    /// </summary>
    public class ParcelaService : IParcelaService
	{
        /// <summary>
        /// IConfiguration
        /// </summary>
        private readonly IConfiguration Configuration;

        /// <summary>
        /// DI za parcela service
        /// </summary>
        public ParcelaService(IConfiguration Configuration)
		{
            this.Configuration = Configuration;
		}

        /// <summary>
        /// Metoda za komunikaciju sa parcelom
        /// </summary>
        public async Task<ParcelaDto> getParcela(Guid parcelaId)
        {
            using (HttpClient client = new HttpClient())
            {

                Uri url = new Uri($"{Configuration["Services:Parcela"]}api/parcela/{parcelaId}");

                HttpContent content = new StringContent(JsonConvert.SerializeObject(parcelaId));
                content.Headers.ContentType.MediaType = "application/json";

                HttpResponseMessage response = client.GetAsync(url).Result;
                var responseContent = await response.Content.ReadAsStringAsync();
                var k = JsonConvert.DeserializeObject<ParcelaDto>(responseContent);

                return k;
            }
        }
    }
}

