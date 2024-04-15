using _4dev2024.Modules.Clients.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4dev2024.Modules.Clients.Core.DAL.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client));

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Gender)
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasMaxLength(9);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
