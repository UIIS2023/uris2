using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgovorZakupService.DtoModels
{
    public class LicnostDto
    {
        [Key]
        public Guid licnostID { get; set; }
        public string? ime { get; set; }
        public string? prezime { get; set; }
        public string? funkcija { get; set; }

    }
}
