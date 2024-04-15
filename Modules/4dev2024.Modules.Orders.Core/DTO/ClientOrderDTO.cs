namespace _4dev2024.Modules.Orders.Core.DTO
{
    internal class ClientOrderDTO
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
