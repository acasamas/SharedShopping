using System;
using Blacksmith.Validations.Exceptions;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;
using SharedShopping.Tests.Fakes;
using Xunit;

namespace SharedShopping.Tests
{
    public class UnitTest1
    {
        private readonly FakeDomainServices services;

        public UnitTest1()
        {
            this.services = new FakeDomainServices();
        }

        [Fact]
        public void can_create_tag_service()
        {
            ITagService tagService;

            tagService = new TagService(this.services);

            Assert.NotNull(tagService);
        }

        [Fact]
        public void can_create_tag()
        {
            ITagService tagService;
            ITag tag;

            tagService = new TagService(this.services);

            this.services
                .FakeExpenseRepository
                .Tags
                .Clear();

            tag = tagService.getOrCreateTag("Hostelería");
            Assert.Equal(1, this.services.FakeExpenseRepository.Tags.Count);
            Assert.NotNull(tag);
            Assert.Equal("Hostelería", tag.Name);
        }

        [Fact]
        public void can_create_expense()
        {
            IExpenseService expenseService;
            IExpense expense;
            IUser georgeUser, martiUser;
            IUserService userService;

            this.services.FakeExpenseRepository.Users.Clear();
            this.services.FakeExpenseRepository.Debtors.Clear();
            this.services.FakeExpenseRepository.Expenses.Clear();

            userService = new UserService(this.services);
            expenseService = new ExpenseService(this.services);

            georgeUser = userService.createUser("George Mcfly");
            Assert.Equal(1, this.services.FakeExpenseRepository.Users.Count);
            martiUser = userService.createUser("Marti Mcfly");
            Assert.Equal(2, this.services.FakeExpenseRepository.Users.Count);

            expense = expenseService.createExpense(DateTime.Now, "Domino's Pizza", new UserContribution[]
            {
                new UserContribution
                {
                    Amount = 19.95m,
                    User = georgeUser,
                }
            });
            Assert.Equal(1, this.services.FakeExpenseRepository.Expenses.Count);
            Assert.Equal(1, this.services.FakeExpenseRepository.Contributions.Count);
            Assert.Equal(0, this.services.FakeExpenseRepository.Debtors.Count);

            expense.setDebtor(georgeUser);
            Assert.Equal(1, this.services.FakeExpenseRepository.Debtors.Count);
            Assert.Throws<DomainException>(() => expense.setDebtor(georgeUser));

            expense.setDebtor(martiUser);
            Assert.Equal(2, this.services.FakeExpenseRepository.Debtors.Count);
        }
    }
}
