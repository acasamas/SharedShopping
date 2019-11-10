using SharedShopping.Domain.Exceptions;
using System;

namespace SharedShopping.Domain.Models
{
    public class User : AbstractAppDomain, IEquatable<User>
    {
        private string name;

        public User(string name) : base()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set
            {
                stringIsNotEmpty<RequiredUserName>(value);
                this.name = value;
            }
        }

        public bool Equals(User other)
        {
            return this.name == other.name;
        }
    }
}