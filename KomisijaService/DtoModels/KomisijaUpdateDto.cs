using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.DtoModels
{
    public class KomisijaUpdateDto
    {
        public Guid komisijaID { get; set; }

        public Guid predsednikID { get; set; } 
    }
}
