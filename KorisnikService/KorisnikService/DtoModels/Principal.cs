namespace KorisnikService.DtoModels
{
    /// <summary>
    /// Principal
    /// </summary>
    public class Principal
    {
        /// <summary>
        /// Korisnicko ime.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Lozinka korisnika.
        /// </summary>
        public string? Password { get; set; }
    }
}
