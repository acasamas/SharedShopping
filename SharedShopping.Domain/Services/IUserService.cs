using SharedShopping.Domain.Models;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<User> getUsers();
        void addUser(User user);
        IEnumerable<Debt> getDebts(User user);
    }
}
