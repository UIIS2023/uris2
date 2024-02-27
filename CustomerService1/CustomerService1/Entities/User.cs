namespace CustomerService1.Entities
{
    public class User
    {
        /// <summary>
        /// Id korisnika
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Ime
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Prezime
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Username korisnika
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Salt
        /// </summary>
        public string Salt { get; set; }
        
    }
}
