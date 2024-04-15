using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Invoices.Core.Entities
{
    internal class ClientOrder : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
