using ServiceParcela.DtoModels;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IOblikSvojineRepository
    /// </summary>
    ///
    public interface IOblikSvojineRepository
    {

        /// <summary>
        /// funkcija get all oblik svojine
        /// </summary>
        ///
        List<Entities.OblikSvojine> getAllOblikSvojine();


        /// <summary>
        /// get oblik svojine by id
        /// </summary>
        ///
        Entities.OblikSvojine getOblikSvojineByID(Guid id);


        /// <summary>
        /// create oblik svojine
        /// </summary>
        ///
        OblikSvojineDto postOblikSvojine(Entities.OblikSvojine oblikSvojine);


        /// <summary>
        /// update oblik svojine
        /// </summary>
        ///
        OblikSvojineDto putOblikSvojine(Entities.OblikSvojine oblikSvojine);


        /// <summary>
        /// delete oblik svojine
        /// </summary>
        ///
        void deleteOblikSvojine(Guid id);


        /// <summary>
        /// save oblik svojine
        /// </summary>
        ///
        bool saveChanges();
    }
}
