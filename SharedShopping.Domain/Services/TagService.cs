using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using SharedShopping.Domain.Models.Internals;

namespace SharedShopping.Domain.Services
{
    public class TagService : ITagService
    {
        private readonly IValidator validate;
        private readonly IRepository repository;

        public TagService(IValidator validate, IRepository repository)
        {
            this.validate = validate;
            this.repository = repository;
        }

        public ITag getOrCreateTag(string name)
        {
            TagData tagData;

            tagData = this.repository
                .getOrCreateTag(name);

            return new Tag(this.validate, this.repository, tagData);
        }

        public IEnumerable<ITag> getTags()
        {
            return this.repository
                .getTags()
                .map(tag => new Tag(this.validate, this.repository, tag));
        }
    }
}