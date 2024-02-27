using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.DtoModels
{
    public class ClanoviCreationDto
    {
        public Guid clanoviID { get; set; }
        public Guid komisijaID { get; set; }
    }
}
