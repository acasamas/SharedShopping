using SharedShopping.Data.Models;
using SharedShopping.Data.Services.Generics;

namespace SharedShopping.Data.Services
{
    public interface ITagRepository : IAdditiveRepository<TagData>
    {
        TagData getSingleOrDefault(string name);
    }
}