using BudgetScale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetScale.Persistence.Configurations
{
    public class CategoryInformationConfiguration : IEntityTypeConfiguration<CategoryInformation>
    {
        public void Configure(EntityTypeBuilder<CategoryInformation> builder)
        {
            builder.HasKey(e => e.CategoryInformationId);
            

            builder.Property(e => e.Activity).IsRequired().ValueGeneratedNever();

            builder.Property(e => e.Budgeted).IsRequired().ValueGeneratedNever();

            builder.Property(e => e.Available).IsRequired().ValueGeneratedNever();

        }
    }
}