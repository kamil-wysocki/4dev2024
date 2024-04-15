using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Products.Core.Entities
{
    internal record Product : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxValue { get; set; }
    }
}
