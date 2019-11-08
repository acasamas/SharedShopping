using SharedShopping.Data.Models;

namespace SharedShopping.Data.Services
{
    public interface IUserRepository : IAdditiveRepository<UserData>
    {
        UserData getSingle(string userName);
        UserData getSingle(int userId);
    }
}