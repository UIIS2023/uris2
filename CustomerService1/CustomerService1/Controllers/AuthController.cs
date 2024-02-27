using CustomerService1.Helper;
using CustomerService1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace CustomerService1.Controllers
{
    [ApiController]
    [Route("api/autentifikacija")]
    [Produces("application/json", "application/xml")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHelper authenticationHelper;
        public AuthController(IAuthHelper authenticationHelper)
        {
            this.authenticationHelper = authenticationHelper;
        }

        /// <summary>
        /// Sluzi za autentifikaciju korisnika
        /// </summary>
        /// <param name="principal">Model sa podacima na osnovu kojih se vrši autentifikacija</param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Authenticate([FromBody] Principal principal)
        {
            //Pokušaj autentifikacije
            if (authenticationHelper.authenticatePrincipal(principal))
            {
                var tokenString = authenticationHelper.generateJWT(principal);
                return Ok(new { token = tokenString });
            }

            //Ukoliko autentifikacija nije uspela vraća se status 401
            return StatusCode(StatusCodes.Status401Unauthorized, "Unauthorized");
        }
    }
}
