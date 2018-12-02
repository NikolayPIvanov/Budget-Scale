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

            builder.HasOne(e => e.Category)
            .WithMany(c => c.CategoryInformation)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Activity).IsRequired().ValueGeneratedNever();

            builder.Property(e => e.Budgeted).IsRequired().ValueGeneratedNever();

            builder.Property(e => e.Available).IsRequired().ValueGeneratedNever();

        }
    }
}