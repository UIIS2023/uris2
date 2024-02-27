using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Entities;
using UgovorZakupService.Repository;

namespace UgovorZakupService.ServiceCalls
{
    public class LicnostService : ILicnostService
    {
        public LicnostService() { }

        public Task<LicnostDto> getLicnost(Guid licnostID)
        {
            LicnostDto licnost = new LicnostDto();

            licnost.licnostID = Guid.Parse("{0165CAE3-A5B6-43CA-9454-3A5DCFD3E29B}");
            licnost.ime = "test ime";
            licnost.prezime = "test prezime";
            licnost.funkcija = "test funkcija";

            return Task.FromResult<LicnostDto>(licnost);
        }
    }
}
