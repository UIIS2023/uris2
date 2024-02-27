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
    public class DokumentService : IDokumentService
    {
        public DokumentService() { }

        public Task<DokumentDto> getDokument(Guid dokumentID) 
        {
            DokumentDto dokument = new DokumentDto();

            dokument.dokumentID = Guid.Parse("{2BC1D042-27B2-414A-9F92-9CA6CBAA882B}");
            dokument.zavodniBroj = "123";
            dokument.datum = DateTime.Parse("2022-12-12");
            dokument.datumDonosenjaDokumenta = DateTime.Parse("2022-12-12");
            dokument.sablon = "test sablon";

            return Task.FromResult<DokumentDto>(dokument);
        }
    }
}
