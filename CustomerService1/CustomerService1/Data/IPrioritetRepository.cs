using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Data
{
    public interface IPrioritetRepository
    {
        //get all prioritet
        /// <summary>
        /// Metoda vraca sve prioritete
        /// </summary>
        /// <returns>Lista prioriteta</returns>
        List<Prioritet> getAllPrioritet();
        //get prioritet by id
        /// <summary>
        /// Metoda vraca prioritet sa zeljenim id-jem
        /// </summary>
        /// <param name="id">Id prioriteta</param>
        /// <returns>Jedan prioritet</returns>
        Prioritet getPrioritetById(Guid id);
        //create prioritet
        /// <summary>
        /// Metoda kreira novi prioritet
        /// </summary>
        /// <param name="prioritet">Model prioriteta</param>
        /// <returns>Potvrda o kreiranom novom prioritetu</returns>
        PrioritetConfirmation postPrioritet(Prioritet prioritet);
        //update prioritet
        /// <summary>
        /// Metoda modifikuje prioritet
        /// </summary>
        /// <param name="prioritet">Model prioriteta</param>
        /// <returns>Potvrda o modifikovanom prioritetu</returns>
        PrioritetConfirmation updatePrioritet(Prioritet prioritet);
        //delete prioritet
        /// <summary>
        /// Metoda brise prioritet
        /// </summary>
        /// <param name="id">Id prioriteta</param>
        void deletePrioritet(Guid id);
        //sacuvaj promene
        /// <summary>
        /// Metoda cuva promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
