using CustomerService1.Entities;

namespace CustomerService1.Data
{
    public interface IKupacRepository
    {
        //get all kupac
        /// <summary>
        /// Metoda vraca sve kupce
        /// </summary>
        /// <returns>Lista kupaca</returns>
        List<Kupac> getAllKupci();
        //get kupac by id
        /// <summary>
        /// Metoda vraca kupca sa zeljenim id-jem
        /// </summary>
        /// <param name="id">Id kupca</param>
        /// <returns>Jedan kupac</returns>
        Kupac getKupacById(Guid id);
        //create kupac
        /// <summary>
        /// Metoda kreira novog kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns>Potvrda o kreiranom novom kupcu</returns>
        KupacConfirmation postKupac(Kupac kupac);
        //update kupac
        /// <summary>
        /// Metoda modifikuje kupca
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns>Potvrda o modifikovanom kupcu</returns>
        KupacConfirmation updateKupac(Kupac kupac);
        //delete kupac
        /// <summary>
        /// Metoda brise kupca
        /// </summary>
        /// <param name="id">Id kupca</param>
        void deleteKupac(Guid id);
        //sacuvaj promene
        /// <summary>
        /// Metoda cuva promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
