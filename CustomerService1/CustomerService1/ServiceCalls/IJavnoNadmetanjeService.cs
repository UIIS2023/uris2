using CustomerService1.Models;

namespace CustomerService1.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        /// <summary>
        /// Metoda vraca javno nadmetanje
        /// </summary>
        /// <param name="javnoNadmetanjeId">Id javnog nadmetanja</param>
        /// <returns>Javno nadmetanje</returns>
        Task<JavnoNadmetanjeDto> getJavnoNadmetanje(Guid javnoNadmetanjeId);
    }
}
