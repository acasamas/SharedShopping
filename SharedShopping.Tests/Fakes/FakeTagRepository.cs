using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;

namespace SharedShopping.Tests.Fakes
{
    public class FakeTagRepository : ITagRepository
    {
        public FakeTagRepository()
        {
            this.Tags = new List<TagData>();
        }

        public ICollection<TagData> Tags { get; }

        public Type ElementType => this.Tags.AsQueryable().ElementType;
        public Expression Expression => this.Tags.AsQueryable().Expression;
        public IQueryProvider Provider => this.Tags.AsQueryable().Provider;

        public IEnumerator<TagData> GetEnumerator()
        {
            return this.Tags.GetEnumerator();
        }

        public TagData getSingleOrDefault(string name)
        {
            return this
                .Tags
                .SingleOrDefault(t => t.Name == name)?
                .mapTo<TagData>();
        }

        public void set(TagData data)
        {
            TagData dbData;

            if (data.Id.HasValue)
            {
                dbData = this.Tags.Single(e => e.Id == data.Id);
                data.mapTo(dbData);
            }
            else
            {
                data.Id = this.Tags.Count + 1;
                dbData = data.mapTo<TagData>();
                this.Tags.Add(dbData);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Tags.GetEnumerator();
        }
    }
}