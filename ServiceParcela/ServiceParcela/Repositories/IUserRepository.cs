namespace ServiceParcela.Repositories
{
    /// <summary>
    /// IUserRepository
    /// </summary>
    ///
    public interface IUserRepository
    {
        /// <summary>
        /// checkIfUserExists
        /// </summary>
        ///
        bool checkIfUserExists(string username, string password);
    }
}
