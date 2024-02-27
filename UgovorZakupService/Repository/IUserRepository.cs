namespace UgovorZakupService.Repository
{
    public interface IUserRepository
    {
        bool checkIfUserExists(string username, string password);
    }
}
