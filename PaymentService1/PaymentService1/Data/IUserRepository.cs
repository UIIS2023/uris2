namespace PaymentService1.Data
{
    /// <summary>
    /// Interfejs IUserRepository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Metoda proverava da li korisnik postoji
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool checkIfUserExists(string username, string password);

    }
}
