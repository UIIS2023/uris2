using Microsoft.IdentityModel.Tokens;
using ServiceParcela.DtoModels;
using ServiceParcela.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace ServiceParcela.Helper
{
    /// <summary>
    /// AuthHelper
    /// </summary>
    /// 
    public class AuthHelper : IAuthHelper
    {
        private readonly IConfiguration configuration;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// AuthHelper
        /// </summary>
        /// 
        public AuthHelper(IConfiguration configuration, IUserRepository userRepository)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
        }
        /// <summary>
        /// authenticatePrincipal
        /// </summary>
        /// 
        public bool authenticatePrincipal(Principal principal)
        {
            if (userRepository.checkIfUserExists(principal.Username, principal.Password))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// generateJWT
        /// </summary>
        /// 
        public string generateJWT(Principal principal)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Issuer"],
                                             null,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
