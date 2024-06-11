using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectType.Domain.Entities;

namespace ProjectType.Infrastructure.Data.Configurations;

public class BusinessTypeConfigurations : IEntityTypeConfiguration<BusinessType>
{
    public void Configure(EntityTypeBuilder<BusinessType> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}