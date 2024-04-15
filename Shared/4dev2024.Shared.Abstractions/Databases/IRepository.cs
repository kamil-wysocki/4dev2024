namespace _4dev2024.Shared.Abstractions.Databases
{
    public interface IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey> 
        where TKey : struct
    {
        Task<TEntity?> GetByIdAsync(TKey id);

        Task<IReadOnlyList<TEntity>> GetAsync();

        Task AddAsync(TEntity entity);

        Task DeleteAsync(TKey id);

        Task UpdateAsync(TEntity entity);
    }
}
