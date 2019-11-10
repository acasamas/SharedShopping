using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class UserService : AbstractService, IUserService
    {
        private readonly IUserRepository users;

        public UserService(IUserRepository users) 
            : base()
        {
            this.assert.isNotNull(users);
            this.users = users;
        }

        public IEnumerable<User> getUsers()
        {
            return this.users
                .map(map);
        }

    }
}