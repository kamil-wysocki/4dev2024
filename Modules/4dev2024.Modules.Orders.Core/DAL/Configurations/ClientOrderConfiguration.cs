using _4dev2024.Modules.Orders.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4dev2024.Modules.Orders.Core.DAL.Configurations
{
    internal class ClientOrderConfiguration : IEntityTypeConfiguration<ClientOrder>
    {
        public void Configure(EntityTypeBuilder<ClientOrder> builder)
        {
            builder.ToTable(nameof(ClientOrder));

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

            builder.Property(p => p.Phone)
                .HasMaxLength(9);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
