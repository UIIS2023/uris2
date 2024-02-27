using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.DtoModels
{
    public class LicnostDto
    {
        public Guid licnostID { get; set; }

        public string? imeLicnosti { get; set; }

        public string? funkcija { get; set; }

    }
}
