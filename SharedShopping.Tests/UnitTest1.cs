using System;
using Blacksmith.Validations;
using Blacksmith.Validations.Exceptions;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;
using SharedShopping.Domain.Validations;
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
                .FakeRepository
                .Tags
                .Clear();

            tag = tagService.getOrCreateTag("Hostelería");
            Assert.Equal(1, this.services.FakeRepository.Tags.Count);
            Assert.NotNull(tag);
            Assert.Equal("Hostelería", tag.Name);
        }

        [Fact]
        public void can_create_expense()
        {
            IExpenseService expenseService;
            IExpense expense;

            expenseService = new ExpenseService(this.services);

            expense = expenseService.createExpense(DateTime.Now, "Domino's Pizza", new NewContribution[]
            {
                new NewContribution
                {
                     Amount = 19.95m,

                }
            });
            throw new NotImplementedException();
        }
    }
}
