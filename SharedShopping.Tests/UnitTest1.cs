using System;
using System.Linq;
using Blacksmith.Validations.Exceptions;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Exceptions;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;
using SharedShopping.Tests.Fakes;
using Xunit;

namespace SharedShopping.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void can_create_tag()
        {
            FakeTagRepository tags; 
            ITagService tagService;
            Tag tag;

            tags = new FakeTagRepository();
            tagService = new TagService(tags);

            tag = new Tag("Hostelería");
            tagService.save(tag);
            Assert.Equal(1, tags.Tags.Count);
            Assert.Equal("Hostelería", tags.Tags[0].Name);
        }

        [Fact]
        public void can_create_expense()
        {
            Expense expense;
            User georgeUser, martiUser;
            Tag restaurantTag;
            IExpenseService expenseService;
            FakeExpenseRepository expenseRespository;

            georgeUser = new User("George Mcfly");
            martiUser = new User("Marti Mcfly");

            expense = new Expense(1, DateTime.Now, "Domino's Pizza", new Contribution[]
            {
                new Contribution(georgeUser, 19.95m),
            });

            expense.setDebtor(georgeUser);
            Assert.Throws<AlreadyAddedExpenseDebtor>(() => expense.setDebtor(georgeUser));

            expense.setDebtor(martiUser);

            restaurantTag = new Tag("Restaurants and Coffee shops");
            expense.setTag(restaurantTag);

            expenseRespository = new FakeExpenseRepository();
            expenseService = new ExpenseService(expenseRespository);
            expenseService.save(expense);

            Assert.Equal(1, expenseRespository.Expenses.Count);
            Assert.Equal("Domino's Pizza", expenseRespository.Expenses[0].Expense.Concept);

            Assert.Single(expenseRespository.Expenses[0].Contributions);
            Assert.Equal("George Mcfly", expenseRespository.Expenses[0].Contributions.ToList()[0].User.Name);
            Assert.Equal(19.95m, expenseRespository.Expenses[0].Contributions.ToList()[0].Amount);

            Assert.Single(expenseRespository.Expenses[0].Debtors, d => d.Name == "Marti Mcfly");
            Assert.Single(expenseRespository.Expenses[0].Debtors, d => d.Name == "George Mcfly");

            Assert.Single(expenseRespository.Expenses[0].Tags);
            Assert.Single(expenseRespository.Expenses[0].Tags, t => t.Name == "Restaurants and Coffee shops");

        }
    }
}
