using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.EntityConfig
{
    public class CollaboratorConfig : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("Contributors");

            builder.HasKey(prop => prop.CPF)
            .HasName("Pk_CollaboratorCpf");
            
            builder.Property(prop => prop.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();
            
            builder.Property(prop => prop.BirthDate)
            .HasColumnType("datetime")
            .IsRequired();
            
            builder.Property(prop => prop.Phone)
            .HasColumnType("varchar(14)")
            .IsRequired();
            
            builder.Property(prop => prop.Gender)
            .HasColumnType("varchar(2)")
            .IsRequired();

            builder.HasOne(x => x.Address)
            .WithMany(x => x.Collaborator)
            .HasForeignKey(x => x.AddressId);

        }
    }
}