using Blacksmith.Validations;
using Blacksmith.Validations.Exceptions;
using SharedShopping.Data.Services;
using SharedShopping.Domain;
using SharedShopping.Domain.Localizations;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SharedShopping.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void can_create_tag_service()
        {
            IDomainCore domainCore;
            ITagService tagService;
            IDomainStrings strings;
            FakeRepository repository;

            repository = new FakeRepository();
            strings = new EsDomainStrings();
            domainCore = new DomainCore(strings, repository);

            tagService = new TagService(domainCore);

            Assert.NotNull(tagService);
        }

        [Fact]
        public void can_create_tag()
        {
            ITagService tagService;
            IDomainStrings strings;
            IValidator validator;
            IRepository repository;
            ITag tag;

            repository = new FakeRepository();
            strings = new EsDomainStrings();
            validator = new Validator<DomainException>(strings, message => new DomainException(message));
            tagService = new TagService(validator, repository);

            tag = tagService.getOrCreateTag("Hostelería");

            Assert.NotNull(tag);
            Assert.Equal("Hostelería", tag.Name);
        }
    }
}
