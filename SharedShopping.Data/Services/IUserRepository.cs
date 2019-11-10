using SharedShopping.Data.Models;
using SharedShopping.Data.Services.Generics;

namespace SharedShopping.Data.Services
{
    public interface IUserRepository : IAdditiveRepository<UserData>
    {
        UserData getSingleOrDefault(string userName);
        UserData getSingle(int userId);
    }
}