using System;
using System.Collections.Generic;
using SharedShopping.Domain.Exceptions;

namespace SharedShopping.Domain.Models
{
    public class Expense : AbstractAppDomain, IEquatable<Expense>
    {
        private int id;
        private string concept;
        private DateTime date;
        private readonly ISet<Tag> tags;
        private readonly ISet<Contribution> contributions;
        private readonly ISet<User> debtors;

        public Expense(int id, DateTime date, string concept, IEnumerable<Contribution> contributions)
        {
            this.Id = id;

            this.Date = date;
            this.Concept = concept;
            this.tags = new HashSet<Tag>();
            this.contributions = new HashSet<Contribution>();
            this.debtors = new HashSet<User>();

            foreach (Contribution contribution in contributions)
            {
                bool added;

                added = this.contributions.Add(contribution);
                isTrue(added, () => new AlreadyAddedExpenseContributor(contribution));
            }
        }

        public int Id
        {
            get => this.id;
            set
            {
                isTrue<OutOfRangeExpenseIdDomainException>(0 < value);
                this.id = value;
            }
        }

        public string Concept
        {
            get => this.concept;
            set
            {
                stringIsNotEmpty<RequiredExpenseConceptDomainException>(value);
                this.concept = value;
            }
        }

        public DateTime Date
        {
            get => this.date;
            private set
            {
                dateIsValid(value);
                this.date = value;
            }
        }

        public IEnumerable<Contribution> Contributions => this.contributions;

        public IEnumerable<User> Debtors => this.debtors;

        public IEnumerable<Tag> Tags => this.tags;

        public void setDebtor(User user)
        {
            bool added;

            this.assert.isNotNull(user);
            added = this.debtors.Add(user);
            isTrue(added, () => new AlreadyAddedExpenseDebtor(user));
        }

        public void setTag(Tag tag)
        {
            bool added;

            this.assert.isNotNull(tag);
            added = this.tags.Add(tag);
            isTrue(added, () => new AlreadyAddedExpenseTag(tag));
        }

        public bool Equals(Expense other)
        {
            return this.Id == other.Id;
        }
    }
}
