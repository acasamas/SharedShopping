using SharedShopping.Domain.Models;
using System.Collections.Generic;

namespace SharedShopping.Domain.Services
{
    public interface ITagService
    {
        ITag getOrCreateTag(string name);
        IEnumerable<ITag> getTags();
    }
}
