using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
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
            TagData tag;

            tag = this.services
                .Tags
                .getSingleOrDefault(name);

            if(tag == null)
            {
                tag = new TagData
                {
                    Name = name,
                };

                this.services.Tags.set(tag);
            }

            return tag.mapTo(prv_createDomainInstance<TagData, PrvTag>);
        }

        public IEnumerable<ITag> getTags()
        {
            return this.services
                .Tags
                .map(prv_createDomainInstance<TagData, PrvTag>);
        }
    }
}