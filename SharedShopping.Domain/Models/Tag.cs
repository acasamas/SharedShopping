using SharedShopping.Domain.Exceptions;
using System;

namespace SharedShopping.Domain.Models
{
    public class Tag : AbstractAppDomain, IEquatable<Tag>
    {
        private string name;

        public Tag(string name) : base()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            set
            {
                base.stringIsNotEmpty<RequiredTagNameDomainException>(value);
                this.name = value;
            }
        }

        public bool Equals(Tag other)
        {
            return this.name == other.name;
        }
    }
}