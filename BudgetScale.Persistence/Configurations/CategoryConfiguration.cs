using BudgetScale.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetScale.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId);

            builder.Property(e => e.CategoryName).IsRequired(true).HasMaxLength(30);

            builder.Property(e => e.GroupId).IsRequired(true);

            builder.Property(e => e.ModifiedOn).HasDefaultValue(null);

            builder.HasOne(e => e.Group)
            .WithMany(g => g.Categories)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}