using KomisijaService.DtoModels;

namespace KomisijaService.Helper
{
    public interface IAuthHelper
    {
        public bool AuthenticatePrincipal(Principal principal);
        public string GenerateJwt(Principal principal);

    }
}
