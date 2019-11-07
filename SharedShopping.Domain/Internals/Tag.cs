using System.Collections.Generic;
using Blacksmith.Validations;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using System;
using SharedShopping.Domain.Services;

namespace SharedShopping.Domain.Internals
{
    internal class Tag : AbstractDomainModel<TagData>, ITag
    {

        public Tag(IDomainServices services, string name) 
            : base(services, prv_buildData(services.Repository, name)) { }

        public Tag(IDomainServices services, TagData dataItem) 
            : base(services, dataItem) { }

        public string Name
        {
            get => this.dataItem.Name;
            set
            {
                this.services.Validator.stringIsNotEmpty(value, this.services.Strings.Tag_name_cannot_be_empty);
                this.dataItem.Name = value;
                this.services.Repository.saveOrCreate(this.dataItem);
            }
        }

        public IEnumerable<IExpense> Expenses => this.services
            .Repository
            .getExpensesByTag(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ExpenseData, Expense>);

        protected override void prv_validate(TagData data)
        {
            this.services.Asserts.stringIsNotEmpty(data.Name, this.services.Strings.Tag_name_cannot_be_empty);
            this.services.Asserts.isTrue(data.Id.HasValue, this.services.Strings.Data_object_has_no_id);
        }

        private static TagData prv_buildData(IRepository repository, string name)
        {
            TagData tagData;

            tagData = new TagData
            {
                Name = name,
            };

            repository.saveOrCreate(tagData);
            return tagData;
        }

    }
}