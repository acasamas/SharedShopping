using SharedShopping.Domain.Models;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface IUserService
    {
        IUser createUser(string name);
        IEnumerable<IUser> getUsers();
    }
}
