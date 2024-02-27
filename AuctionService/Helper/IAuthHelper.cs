using AuctionService.DtoModels;

namespace AuctionService.Helper
{
    public interface IAuthHelper
    {
        public bool authenticatePrincipal(Principal principal);
        public string generateJWT(Principal principal);
    }
}
