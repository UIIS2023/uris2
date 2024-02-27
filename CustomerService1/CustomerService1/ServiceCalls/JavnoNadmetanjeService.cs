using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public class JavnoNadmetanjeService : IJavnoNadmetanjeService
    {
        public JavnoNadmetanjeService() { }
        public Task<JavnoNadmetanjeDto> getJavnoNadmetanje(Guid javnoNadmetanjeId)
        {
            throw new NotImplementedException();
        }
    }
}
