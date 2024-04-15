namespace _4dev2024.Modules.Products.Core.DTO
{
    internal record ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TaxValue { get; set; }
    }
}
