using System.Linq;

namespace SharedShopping.Data.Services
{
    public interface IEnumerableRepository<T> : IQueryable<T>
    {
    }
}