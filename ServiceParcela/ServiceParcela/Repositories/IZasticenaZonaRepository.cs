using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IZasticenaZonaRepository
    /// </summary>
    ///
    public interface IZasticenaZonaRepository
    {

        /// <summary>
        /// funkcija get all zasticena zona
        /// </summary>
        ///
        List<Entities.ZasticenaZona> getAllZasticenaZona();


        /// <summary>
        /// get zasticena zona by id
        /// </summary>
        ///
        Entities.ZasticenaZona getZasticenaZonaByID(Guid id);


        /// <summary>
        /// create zasticena zona
        /// </summary>
        ///
        ZasticenaZonaDto postZasticenaZona(Entities.ZasticenaZona zasticenaZona);


        /// <summary>
        /// update zasticena zona
        /// </summary>
        ///
        ZasticenaZonaDto putZasticenaZona(Entities.ZasticenaZona zasticenaZona);


        /// <summary>
        /// delete zasticena zona
        /// </summary>
        ///
        void deleteZasticenaZona(Guid id);


        /// <summary>
        /// save zasticena zona
        /// </summary>
        ///
        bool saveChanges();
    }
}
