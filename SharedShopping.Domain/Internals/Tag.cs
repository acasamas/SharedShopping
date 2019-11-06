﻿using System.Collections.Generic;
using Blacksmith.Validations;
using Blacksmith.Automap.Extensions;
using SharedShopping.Data.Models;
using SharedShopping.Data.Services;
using SharedShopping.Domain.Models;
using System;

namespace SharedShopping.Domain.Internals
{
    internal class Tag : AbstractDomainModel<TagData>, ITag
    {

        public Tag(IValidator validate
            , IRepository repository
            , string name) : base(validate, repository, prv_buildData(repository, name)) { }

        public Tag(IValidator validate, IRepository repository, TagData dataItem) 
            : base(validate, repository, dataItem) { }

        public string Name
        {
            get => this.dataItem.Name;
            set
            {
                this.validate.stringIsNotEmpty(value);
                this.dataItem.Name = value;
                this.repository.saveOrCreate(this.dataItem);
            }
        }

        public IEnumerable<IExpense> Expenses => this.repository
            .getExpensesByTag(this.dataItem.Id.Value)
            .map(prv_createDomainInstance<ExpenseData, Expense>);

        protected override void prv_validate(TagData data)
        {
            this.assert.stringIsNotEmpty(data.Name);
            this.assert.isTrue(data.Id.HasValue, "TagData has no Id.");
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