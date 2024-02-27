using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IKulturaRepository
    /// </summary>
    ///
    public interface IKulturaRepository
    {

        /// <summary>
        /// funkcija get all kultura
        /// </summary>
        ///
        List<Entities.Kultura> getAllKultura();


        /// <summary>
        /// get kultura by id
        /// </summary>
        ///
        Entities.Kultura getKulturaByID(Guid id);


        /// <summary>
        /// create kultura
        /// </summary>
        ///
        KulturaDto postKultura(Entities.Kultura kultura);


        /// <summary>
        /// update kultura
        /// </summary>
        ///
        KulturaDto putKultura(Entities.Kultura kultura);


        /// <summary>
        /// delete kultura
        /// </summary>
        ///
        void deleteKultura(Guid id);


        /// <summary>
        /// save kultura
        /// </summary>
        ///
        bool saveChanges();
    }
}
