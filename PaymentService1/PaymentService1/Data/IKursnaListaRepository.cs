using PaymentService1.Entities;

namespace PaymentService1.Data
{
    public interface IKursnaListaRepository
    {
        /// <summary>
        /// Metoda vraca sve kureve
        /// </summary>
        /// <returns>Vraca se lista kurseva</returns>
        //get all kurs
        List<KursnaLista> getAllKurs();
        /// <summary>
        /// Metoda vraca kurs sa zeljenim id-jel
        /// </summary>
        /// <param name="id">Id kursa</param>
        /// <returns>Tacno jedan kurs</returns>
        //get kurs by id
        KursnaLista getKursById(Guid id);
        //create kurs
        /// <summary>
        /// Metoda kreira novu kursnu listu
        /// </summary>
        /// <param name="kurs">Model kursa</param>
        /// <returns>Vraca potvrdu o kreiranom kursu</returns>
        KursnaListaConfirmation postKurs(KursnaLista kurs);
        //update kurs
        /// <summary>
        /// Metoda modifikuje kurs
        /// </summary>
        /// <param name="kurs">Model kursa</param>
        /// <returns>Vraca potvrdu o modifikovanom kursu</returns>
        KursnaListaConfirmation updateKurs(KursnaLista kurs);
        //delete kurs
        /// <summary>
        /// Metoda brise zeljeni kurs
        /// </summary>
        /// <param name="id">Id kursa</param>
        void deleteKurs(Guid id);
        //sacuvaj promene
        /// <summary>
        /// Metoda cuva promene
        /// </summary>
        /// <returns></returns>
        bool SaveChanges();
    }
}
