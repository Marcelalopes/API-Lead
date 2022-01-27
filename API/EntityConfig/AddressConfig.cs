using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.EntityConfig
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Adresses");

            builder.HasKey(prop => prop.Id)
              .HasName("Pk_AddressId");

            builder.Property(prop => prop.Street)
              .HasColumnType("varchar(50)")
              .IsRequired();

            builder.Property(prop => prop.Number)
              .HasColumnType("varchar(10)")
              .IsRequired();

            builder.Property(prop => prop.District)
              .HasColumnType("varchar(50)")
              .IsRequired();

            builder.Property(prop => prop.City)
              .HasColumnType("varchar(50)")
              .IsRequired();

            builder.Property(prop => prop.State)
            .HasColumnType("varchar(3)")
            .IsRequired();
        }
    }
}