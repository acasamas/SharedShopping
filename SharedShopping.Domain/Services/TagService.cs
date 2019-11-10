using System.Collections.Generic;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;

namespace SharedShopping.Domain.Services
{
    public class TagService : AbstractService, ITagService
    {
        private readonly ITagRepository tags;

        public TagService(ITagRepository tags) : base()
        {
            this.assert.isNotNull(tags);
            this.tags = tags;
        }

        public IEnumerable<Tag> getTags()
        {
            return this.tags.map(map);
        }

        public void save(Tag tag)
        {
            TagData data;

            data = this
                .tags
                .getSingleOrDefault(tag.Name)
                ?? new TagData();

            tag.mapTo(data);
            this.tags.set(data);
        }
    }
}