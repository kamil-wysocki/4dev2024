using System.ComponentModel.DataAnnotations;

namespace _4dev2024.Modules.Clients.Core.DTO
{
    internal record ClientDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string Gender { get; set; }

        [StringLength(9, MinimumLength = 9)]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
