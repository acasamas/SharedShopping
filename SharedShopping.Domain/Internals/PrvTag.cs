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
    internal class PrvTag : PrvAbstractDomainService<TagData>, ITag
    {

        public PrvTag(IDomainServices services, string name) 
            : base(services, prv_buildData(services.Tags, name)) { }

        public PrvTag(IDomainServices services, TagData dataItem) 
            : base(services, dataItem) { }

        public string Name
        {
            get => this.dataItem.Name;
            set
            {
                this.services.Validator.stringIsNotEmpty(value, this.services.Strings.Tag_name_cannot_be_empty);
                this.dataItem.Name = value;
                this.services.Tags.set(this.dataItem);
            }
        }

        public IEnumerable<IExpense> Expenses => this.services
            .TaggedExpenses
            .getExpensesByTag(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ExpenseData, PrvExpense>);

        protected override void prv_validate(TagData data)
        {
            this.services.Asserts.stringIsNotEmpty(data.Name, this.services.Strings.Tag_name_cannot_be_empty);
            this.services.Asserts.isTrue(data.Id.HasValue, this.services.Strings.Data_object_has_no_id);
        }

        private static TagData prv_buildData(ITagRepository repository, string name)
        {
            return repository.getSingleOrDefault(name);
        }

    }
}