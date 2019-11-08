using SharedShopping.Data.Models;

namespace SharedShopping.Data.Services
{
    public interface ITagRepository : IAdditiveRepository<TagData>
    {
        TagData getSingleOrDefault(string name);
    }
}