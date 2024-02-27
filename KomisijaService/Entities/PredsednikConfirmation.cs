using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.Entities
{
    public class PredsednikConfirmation
    {
        [Key]
        public Guid predsednikID { get; set; }
    }
}
