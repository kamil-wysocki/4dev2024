namespace _4dev2024.Shared.Abstractions.Databases
{
    public interface IEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
