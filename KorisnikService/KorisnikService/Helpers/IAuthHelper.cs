using KorisnikService.DtoModels;

namespace KorisnikService.Helpers
{
    public interface IAuthHelper
    {
        public bool authenticatePrincipal(Principal principal);
        public string generateJWT(Principal principal);
    }
}
