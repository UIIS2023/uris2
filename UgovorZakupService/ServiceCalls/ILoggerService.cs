using UgovorZakupService.DtoModels;

namespace UgovorZakupService.ServiceCalls
{
    public interface ILoggerService
    {
        void CreateMessage(Message message);
    }
}
