using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using Blacksmith.Validations;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Internals;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class TagService : AbstractService, ITagService
    {
        public TagService(IValidator validate, IRepository repository) : base(validate, repository)
        {
        }

        public ITag getOrCreateTag(string name)
        {
            return this.repository
                .getOrCreateTag(name)
                .mapTo(prv_createDomainInstance<TagData, Tag>);
        }

        public IEnumerable<ITag> getTags()
        {
            return this.repository
                .getTags()
                .map(prv_createDomainInstance<TagData, Tag>);
        }
    }
}