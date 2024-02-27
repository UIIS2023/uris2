using UgovorZakupService.DtoModels;

namespace UgovorZakupService.ServiceCalls
{
    public interface IKupacService
    {
        Task<KupacDto> getKupac(Guid kupacID);
    }
}
