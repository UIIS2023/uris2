using ServiceParcela.DtoModels;

namespace ServiceParcela.Helper
{
    /// <summary>
    /// AuthHelper
    /// </summary>
    ///
    public interface IAuthHelper
    {
        /// <summary>
        /// authenticatePrincipal
        /// </summary>
        ///
        public bool authenticatePrincipal(Principal principal);
        /// <summary>
        /// generateJWT
        /// </summary>
        ///
        public string generateJWT(Principal principal);
    }
}
