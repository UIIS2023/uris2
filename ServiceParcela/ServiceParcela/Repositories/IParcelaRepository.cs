using ServiceParcela.DtoModels;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IParcelaRepository
    /// </summary>
    ///
    public interface IParcelaRepository
    {

        /// <summary>
        /// funkcija get all parcela
        /// </summary>
        ///
        List<Entities.Parcela> getAllParcela();


        /// <summary>
        /// get parcela by id
        /// </summary>
        ///
        Entities.Parcela getParcelaByID(Guid id);


        /// <summary>
        /// create parcela
        /// </summary>
        ///
        ParcelaDto postParcela(Entities.Parcela parcela);


        /// <summary>
        /// update parcela
        /// </summary>
        ///
        ParcelaDto putParcela(Entities.Parcela parcela);


        /// <summary>
        /// delete parcela
        /// </summary>
        ///
        void deleteParcela(Guid id);


        /// <summary>
        /// save parcela
        /// </summary>
        ///
        bool saveChanges();
        
    }
}
