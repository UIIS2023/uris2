using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.DtoModels
{
    public class PredsednikDto
    {
        public Guid predsednikID { get; set; }
        
        public LicnostDto? licnost { get; set; }
        
    }
}
