using KomisijaService.DtoModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KomisijaService.ServiceCalls
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfiguration configuration;

        public LoggerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void CreateMessage(Message message)
        {
            using (HttpClient client = new HttpClient())
            {
                
                new Uri($"{ configuration["Services:LoggerService"]}api/logger");

                HttpContent content = new StringContent(JsonConvert.SerializeObject(message));
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                content.Headers.ContentType.MediaType = "application/json";
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            }
        }
    
    }
}
