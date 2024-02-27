using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IOdvodnjavanjeRepository
    /// </summary>
    ///
    public interface IOdvodnjavanjeRepository
    {

        /// <summary>
        /// funkcija get all odvodnjavanje
        /// </summary>
        ///
        List<Entities.Odvodnjavanje> getAllOdvodnjavanje();


        /// <summary>
        /// get odvodnjavanje by id
        /// </summary>
        ///
        Entities.Odvodnjavanje getOdvodnjavanjeByID(Guid id);


        /// <summary>
        /// create odvodnjavanje
        /// </summary>
        ///
        OdvodnjavanjeDto postOdvodnjavanje(Entities.Odvodnjavanje odvodnjavanje);


        /// <summary>
        /// update odvodnjavanje
        /// </summary>
        ///
        OdvodnjavanjeDto putOdvodnjavanje(Entities.Odvodnjavanje odvodnjavanje);


        /// <summary>
        /// delete odvodnjavanje
        /// </summary>
        ///
        void deleteOdvodnjavanje(Guid id);


        /// <summary>
        /// save odvodnjavanje
        /// </summary>
        ///
        bool saveChanges();
        
    }
}
