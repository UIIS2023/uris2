using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UgovorZakupService.DtoModels
{
    public class DokumentDto
    {
        [Key]
        public Guid dokumentID { get; set; }
        public string? zavodniBroj { get; set; }
        public DateTime datum { get; set; }
        public DateTime datumDonosenjaDokumenta { get; set; }
        public string? sablon { get; set; }

    }
}
