using System;
using System.Collections.Generic;

namespace SharedShopping.Domain.Models
{
    public interface IExpense
    {
        int Id { get; }
        IEnumerable<IContribution> Contributions { get; }
        IEnumerable<IUser> Debtors { get; }
        string Concept { get; set; }
        DateTime Date { get; }
        IEnumerable<ITag> Tags { get; }

        void setDebtor(IUser user);
        void setTag(ITag tag);
    }
}
