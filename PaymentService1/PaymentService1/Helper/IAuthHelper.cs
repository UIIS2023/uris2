using PaymentService1.Models;

namespace PaymentService1.Helper
{
    public interface IAuthHelper
    {
        public bool authenticatePrincipal(Principal principal);
        public string generateJWT(Principal principal);
    }
}
