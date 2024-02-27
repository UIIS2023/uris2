using ServiceParcela.DtoModels;
using Newtonsoft.Json;

namespace ServiceParcela.ServiceCalls
{
    /// <summary>
    /// LoggerService
    /// </summary>
    ///
    public class LoggerService : ILogerService
    {
        private readonly IConfiguration configuration;


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="configuration"></param>
        public LoggerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        /// <summary>
        /// Kreiranje poruke - metoda
        /// </summary>
        /// <param name="message"></param>
        public void CreateMessage(Message message)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri url = new Uri($"{configuration["Services:LoggerService"]}api/logger");

                HttpContent content = new StringContent(JsonConvert.SerializeObject(message));
                content.Headers.ContentType.MediaType = "application/json";

            }
        }
    }
}
