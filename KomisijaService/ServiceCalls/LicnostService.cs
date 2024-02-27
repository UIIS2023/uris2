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
    public class LicnostService : ILicnostService
    {
        public Task<LicnostDto> LicnostKomisije(Guid licnostId)
        {
            LicnostDto licnost = new LicnostDto();
            licnost.licnostID = Guid.Parse("a215e4cb-a427-40cf-88b2-8488d140a939");

            return Task.FromResult<LicnostDto>(licnost);
        }
    }
}
