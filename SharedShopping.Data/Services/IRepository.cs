namespace SharedShopping.Data.Services
{
    public interface IRepository<T> : IAdditiveRepository<T>
    {
        void remove(T item);
    }
}