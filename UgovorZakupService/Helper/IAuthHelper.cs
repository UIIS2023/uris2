using UgovorZakupService.DtoModels;

namespace UgovorZakupService.Helper
{
    public interface IAuthHelper
    {
        public bool authenticatePrincipal(Principal principal);
        public string generateJWT(Principal principal);
    }
}
