using ServiceParcela.DtoModels;
using ServiceParcela.Entities;

namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IKatastarskaOpstinaRepository
    /// </summary>
    ///
    public interface IKatastarskaOpstinaRepository
    {

        /// <summary>
        /// funkcija get all katastarska opstina
        /// </summary>
        ///
        List<Entities.KatastarskaOpstina> getAllKatastarskaOpstina();


        /// <summary>
        /// get katastarska opstina by id
        /// </summary>
        ///
        Entities.KatastarskaOpstina getKatastarskaOpstinaByID(Guid id);


        /// <summary>
        /// create katastarska opstina
        /// </summary>
        ///
        KatastarskaOpstinaDto postKatastarskaOpstina(Entities.KatastarskaOpstina katastarskaOpstina);


        /// <summary>
        /// update katastarska opstina
        /// </summary>
        ///
        KatastarskaOpstinaDto putKatastarskaOpstina(Entities.KatastarskaOpstina katastarskaOpstina);


        /// <summary>
        /// delete katastarska opstina
        /// </summary>
        ///
        void deleteKatastarskaOpstina(Guid id);


        /// <summary>
        /// save katastarska opstina
        /// </summary>
        ///
        bool saveChanges();
    }
}
