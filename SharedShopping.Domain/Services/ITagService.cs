using SharedShopping.Domain.Models;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> getTags();
        void save(Tag tag);
    }
}
