using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IKlasaRepository
    /// </summary>
    ///
    public interface IKlasaRepository
    {

        /// <summary>
        /// funkcija get all klasa
        /// </summary>
        ///
        List<Entities.Klasa> getAllKlasa();


        /// <summary>
        /// get klasa by id
        /// </summary>
        ///
        Entities.Klasa getKlasaByID(Guid id);


        /// <summary>
        /// create klasa
        /// </summary>
        ///
        KlasaDto postKlasa(Entities.Klasa klasa);


        /// <summary>
        /// update klasa
        /// </summary>
        ///
        KlasaDto putKlasa(Entities.Klasa klasa);


        /// <summary>
        /// delete klasa
        /// </summary>
        ///
        void deleteKlasa(Guid id);


        /// <summary>
        /// save klasa
        /// </summary>
        ///
        bool saveChanges();
    }
}
