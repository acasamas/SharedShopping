using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Tests.Fakes
{
    public class FakeUserRepository : IUserRepository
    {
        public FakeUserRepository()
        {
            this.Users = new List<UserData>();
        }

        public IList<UserData> Users { get; }

        public IEnumerator<UserData> GetEnumerator()
        {
            return this.Users.GetEnumerator();
        }

        public UserData getSingleOrDefault(string userName)
        {
            return this.Users
                .Single(u => u.Name == userName)
                .mapTo<UserData>();
        }

        public UserData getSingle(int userId)
        {
            return this.Users
                .Single(u => u.Id == userId)
                .mapTo<UserData>();
        }

        public void set(UserData data)
        {
            UserData dbData;

            if (data.Id.HasValue)
            {
                dbData = this.Users.Single(e => e.Id == data.Id);
                data.mapTo(dbData);
            }
            else
            {
                data.Id = this.Users.Count + 1;
                dbData = data.mapTo<UserData>();
                this.Users.Add(dbData);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Users.GetEnumerator();
        }
    }
}