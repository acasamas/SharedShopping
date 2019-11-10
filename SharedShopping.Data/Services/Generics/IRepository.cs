namespace SharedShopping.Data.Services.Generics
{
    public interface IRepository<T> : IAdditiveRepository<T>
    {
        void remove(T item);
    }
}