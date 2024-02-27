using System.Security.Cryptography;
using UgovorZakupService.DtoModels;
using UgovorZakupService.Repository;

namespace UgovorZakupService.Services
{
    public class UserService : IUserRepository
    {
        public static List<User> Users { get; set; } = new List<User>();
        private readonly static int iterations = 1000;
        public UserService()
        {
            FillData();
        }

        private static void FillData()
        {
            var user1 = HashPassword("testpassword");

            Users.AddRange(new List<User>
            {
                new User
                {
                    Id = Guid.Parse("CFD7FA84-8A27-4119-B6DB-5CFC1B0C94E1"),
                    FirstName = "Petar",
                    LastName = "Petrovic",
                    UserName = "petar.petrovic",
                    Email = "petar.petrovic@testmail.com",
                    Password = user1.Item1,
                    Salt = user1.Item2
                }
            });
        }

        public bool checkIfUserExists(string username, string password)
        {
            //Ukoliko je username jedinstveno ovo je uredu
            User? user = Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return false;
            }

            //Ako smo našli korisnika sa tim korisničkim imenom proveravamo lozinku
            if (VerifyPassword(password, user.Password, user.Salt))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Vrši hash-ovanje korisnicke lozinke
        /// </summary>
        /// <param name="password">Korisnicka lozinka</param>
        /// <returns>Generisan hash i salt</returns>
        private static Tuple<string, string> HashPassword(string password)
        {
            var sBytes = new byte[password.Length];
#pragma warning disable SYSLIB0023 // Type or member is obsolete
            new RNGCryptoServiceProvider().GetNonZeroBytes(sBytes);
#pragma warning restore SYSLIB0023 // Type or member is obsolete
            var salt = Convert.ToBase64String(sBytes);

#pragma warning disable SYSLIB0041 // Type or member is obsolete
            var derivedBytes = new Rfc2898DeriveBytes(password, sBytes, iterations);
#pragma warning restore SYSLIB0041 // Type or member is obsolete

            return new Tuple<string, string>
            (
                Convert.ToBase64String(derivedBytes.GetBytes(256)),
                salt
            );
        }

        /// <summary>
        /// Proverava validnost prosleđene lozinke sa prosleđenim hash-om
        /// </summary>
        /// <param name="password">Korisnicka lozinka</param>
        /// <param name="savedHash">Sacuvan hash</param>
        /// <param name="savedSalt">Sacuvan salt</param>
        /// <returns></returns>
        public bool VerifyPassword(string password, string savedHash, string savedSalt)
        {
            var saltBytes = Convert.FromBase64String(savedSalt);
#pragma warning disable SYSLIB0041 // Type or member is obsolete
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, iterations);
#pragma warning restore SYSLIB0041 // Type or member is obsolete
            if (Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == savedHash)
            {
                return true;
            }
            return false;
        }
    }
}
