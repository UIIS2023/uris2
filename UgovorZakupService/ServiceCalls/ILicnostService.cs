using UgovorZakupService.DtoModels;

namespace UgovorZakupService.ServiceCalls
{
    public interface ILicnostService
    {
        Task<LicnostDto> getLicnost(Guid licnostID);
    }
}
