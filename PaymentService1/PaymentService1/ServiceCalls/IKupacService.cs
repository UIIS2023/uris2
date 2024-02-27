using PaymentService1.Models;

namespace PaymentService1.ServiceCalls
{
    public interface IKupacService
    {
        Task<KupacDto> getKupac(Guid kupacId);
    }
}
