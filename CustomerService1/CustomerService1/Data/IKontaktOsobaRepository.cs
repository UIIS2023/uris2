using CustomerService1.Entities;
using CustomerService1.Models;

namespace CustomerService1.Data
{
    /// <summary>
    /// Interfejs IKontaktOsobarepository
    /// </summary>
    public interface IKontaktOsobaRepository
    {
        /// <summary>
        /// Metoda vraca sve kontakt osobe
        /// </summary>
        /// <returns>Lista kontakt osoba</returns>
        //get all kontakt osoba
        List<KontaktOsoba> getAllKontaktOsobe();
        //get kontakt osoba by id
        /// <summary>
        /// Metoda vraca kontakt osobu sa zeljenim id-jem
        /// </summary>
        /// <param name="id">Id kontakt osobe</param>
        /// <returns>Jedna kontakt osoba</returns>
        KontaktOsoba getKontaktOsobaById(Guid id);
        //create kontakt osoba
        /// <summary>
        /// Metoda kreira novu kontakt osobu
        /// </summary>
        /// <param name="kontaktOsoba">Model kontakt osobe</param>
        /// <returns>Potvrda o kreiranoj kontakt osobi</returns>
        KontaktOsobaConfirmation postKontaktOsoba(KontaktOsoba kontaktOsoba);
        //update kontakt osoba
        /// <summary>
        /// Metoda modifikuje kontakt osobu
        /// </summary>
        /// <param name="kontaktOsoba">Model kontakt osobe</param>
        /// <returns>Potvrda o modifikovanoj kontakt osobi</returns>
        KontaktOsobaConfirmation updateKontaktOsoba(KontaktOsoba kontaktOsoba);
        //delete kontakt osoba
        /// <summary>
        /// Metoda brise kontakt osobu
        /// </summary>
        /// <param name="id">Id kontakt osobe</param>
        void deleteKontaktOsoba(Guid id);
        //sacuvaj promene
        /// <summary>
        /// Metoda cuva promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}

