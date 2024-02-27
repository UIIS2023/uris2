namespace AuctionService.Repositories
{
    public interface IUserRepository
    {
        bool checkIfUserExists(string username, string password);
    }
}
