using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Invoices.Core.Entities
{
    internal record Order : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
