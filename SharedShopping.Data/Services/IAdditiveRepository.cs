namespace SharedShopping.Data.Services
{
    public interface IAdditiveRepository<T> : IEnumerableRepository<T>
    {
        void set(T data);
    }
}