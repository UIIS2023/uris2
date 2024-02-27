namespace ServiceParcela.DtoModels
{
    /// <summary>
    /// PrincipalDto
    /// </summary>
    /// 
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
