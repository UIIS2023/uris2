namespace KorisnikService.Repositories
{
    public interface IUserRepository
    {
        bool checkIfUserExists(string username, string password);
    }
}
