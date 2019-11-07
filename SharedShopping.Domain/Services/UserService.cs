using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Domain.Internals;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class UserService : AbstractService, IUserService
    {
        public UserService(IDomainServices services) : base(services)
        {
        }

        public IUser createUser(string name)
        {
            UserData userData;

            this.services.Asserts.stringIsNotEmpty(name);

            userData = new UserData
            {
                 Name = name,
            };

            this.services.Repository.create(userData);
            return userData.mapTo(prv_createDomainInstance<UserData, PrvUser>);
        }

        public IEnumerable<IUser> getUsers()
        {
            return this.services
                .Repository
                .getUsers()
                .map(prv_createDomainInstance<UserData, PrvUser>);
        }
    }
}