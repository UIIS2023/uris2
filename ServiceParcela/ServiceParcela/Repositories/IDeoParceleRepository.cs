using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IDeoParceleRepository
    /// </summary>
    ///
    public interface IDeoParceleRepository
    {

        /// <summary>
        /// funkcija get all deo parcele
        /// </summary>
        ///
        List<Entities.DeoParcele> getAllDeoParcele();


        /// <summary>
        /// get deo parcele by id
        /// </summary>
        ///
        Entities.DeoParcele getDeoParceleByID(Guid id);


        /// <summary>
        /// create deo parcele
        /// </summary>
        ///
        DeoParceleDto postDeoParcele(Entities.DeoParcele deoParcele);


        /// <summary>
        /// update deo parcele
        /// </summary>
        ///
        DeoParceleDto putDeoParcele(Entities.DeoParcele deoParcele);


        /// <summary>
        /// delete deo parcele
        /// </summary>
        ///
        void deleteDeoParcele(Guid id);


        /// <summary>
        /// save deo parcele
        /// </summary>
        ///
        bool saveChanges();
        
    }
}
