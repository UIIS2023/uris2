using UgovorZakupService.DtoModels;

namespace UgovorZakupService.ServiceCalls
{
    public interface IDokumentService
    {
        Task<DokumentDto> getDokument(Guid dokumentID);
    }
}
