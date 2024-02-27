using PaymentService1.Models;

namespace PaymentService1.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        Task<JavnoNadmetanjeDto> getJavnoNadmetanje(Guid javnoNadmetanjeId);
    }
}
