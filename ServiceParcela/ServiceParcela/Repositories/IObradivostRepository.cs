using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IObradivostRepository
    /// </summary>
    ///
    public interface IObradivostRepository
    {

        /// <summary>
        /// funkcija get all obradivost
        /// </summary>
        ///
        List<Entities.Obradivost> getAllObradivost();


        /// <summary>
        /// get obradivost by id
        /// </summary>
        ///
        Entities.Obradivost getObradivostByID(Guid id);


        /// <summary>
        /// create obradivost
        /// </summary>
        ///
        ObradivostDto postObradivost(Entities.Obradivost obradivost);


        /// <summary>
        /// update obradivost
        /// </summary>
        ///
        ObradivostDto putObradivost(Entities.Obradivost obradivost);


        /// <summary>
        /// delete obradivost
        /// </summary>
        ///
        void deleteObradivost(Guid id);


        /// <summary>
        /// save obradivost
        /// </summary>
        ///
        bool saveChanges();
    }
}
