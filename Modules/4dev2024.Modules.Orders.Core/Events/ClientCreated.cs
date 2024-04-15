using _4dev2024.Shared.Abstractions.Events;

namespace _4dev2024.Modules.Orders.Core.Events
{
    public record ClientCreated(Guid Id, string FirstName, string LastName, 
        string Phone, string Address) : IEvent;
}
