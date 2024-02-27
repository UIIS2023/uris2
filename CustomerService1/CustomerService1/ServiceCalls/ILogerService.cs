using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public interface ILogerService
    {
        /// <summary>
        /// Metoda za kreiranje poruke logeru
        /// </summary>
        /// <param name="message"></param>
        void CreateMessage(Message message);
    }
}
