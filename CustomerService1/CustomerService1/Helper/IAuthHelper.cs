using CustomerService1.Models;

namespace CustomerService1.Helper
{
    public interface IAuthHelper
    {
        public bool authenticatePrincipal(Principal principal);
        public string generateJWT(Principal principal);
    }
}
