using ServiceParcela.DtoModels;

namespace ServiceParcela.ServiceCalls
{
    /// <summary>
    /// IKupacService
    /// </summary>
    ///
    public interface IKupacService
    {
        /// <summary>
        /// authenticatePrincipal
        /// </summary>
        ///
        Task<KupacDto> getKupci(Guid kupacId);

    }
}
