using _4dev2024.Shared.Abstractions.Databases;

namespace _4dev2024.Modules.Clients.Core.Entities
{
    internal record Client : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
