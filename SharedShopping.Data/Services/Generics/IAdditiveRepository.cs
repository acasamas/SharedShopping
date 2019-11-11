namespace SharedShopping.Data.Services.Generics
{
    public interface IAdditiveRepository<T> : IEnumerableRepository<T>
    {
        void set(T data);
    }
}