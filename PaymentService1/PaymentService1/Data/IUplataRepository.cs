using PaymentService1.Entities;

namespace PaymentService1.Data
{
    public interface IUplataRepository
    {
        /// <summary>
        /// Metoda vraca sve uplate
        /// </summary>
        /// <returns>Lista uplata</returns>
        //get all uplata
        List<Uplata> getAllUplate();
        //get uplata by id
        /// <summary>
        /// Metoda vraca uplatu sa zeljenim id-jel
        /// </summary>
        /// <param name="id">Id uplate</param>
        /// <returns>Jedna uplata</returns>
        Uplata getUplataById(Guid id);
        //create uplata
        /// <summary>
        /// Metoda kreira novu uplatu
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <returns>Potvrda o kreiranoj uplati</returns>
        UplataConfirmation postUplata(Uplata uplata);
        //update uplata
        /// <summary>
        /// Metoda modifikuje uplatu
        /// </summary>
        /// <param name="uplata">Model uplate</param>
        /// <returns>Potvrda o modifikovanoj uplati</returns>
        UplataConfirmation updateUplata(Uplata uplata);
        //delete uplata
        /// <summary>
        /// Metoda brise uplatu
        /// </summary>
        /// <param name="id">Id uplate</param>
        void deleteUplata(Guid id);
        //sacuvaj promene
        /// <summary>
        /// Metoda cuva promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
