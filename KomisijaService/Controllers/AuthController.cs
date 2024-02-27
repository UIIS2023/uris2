using KomisijaService.Helper;
using KomisijaService.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomisijaService.Controllers
{
    [ApiController]
    [Route("api/komisija")]
    [Produces("application/json", "application/xml")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHelper authHelper;

        public AuthController(IAuthHelper authHelper)
        {
            this.authHelper = authHelper;
        }


        [HttpPost("authenticate")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Authenticate([FromBody] Principal principal)
        {

            if (authHelper.AuthenticatePrincipal(principal))
            {
                var tokenString = authHelper.GenerateJwt(principal);
                return Ok(new { token = tokenString });
            }


            return Unauthorized();
        }
    }
}
