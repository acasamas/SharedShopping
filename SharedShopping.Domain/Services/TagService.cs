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
        public TagService(IDomainServices domainCore) : base(domainCore)
        {
        }

        public ITag getOrCreateTag(string name)
        {
            return this.services
                .Repository
                .getOrCreateTag(name)
                .mapTo(prv_createDomainInstance<TagData, PrvTag>);
        }

        public IEnumerable<ITag> getTags()
        {
            return this.services
                .Repository
                .getTags()
                .map(prv_createDomainInstance<TagData, PrvTag>);
        }
    }
}