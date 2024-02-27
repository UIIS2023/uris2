using UgovorZakupService.DtoModels;

namespace UgovorZakupService.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        Task<JavnoNadmetanjeDto> getJavnoNadmetanje(Guid javnoNadmetanjeID);
    }
}
