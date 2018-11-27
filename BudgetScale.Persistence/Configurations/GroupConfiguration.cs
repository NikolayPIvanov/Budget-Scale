using BudgetScale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetScale.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(e => e.GroupId);

            builder.Property(e => e.GroupName)
            .IsRequired(true)
            .HasMaxLength(30);

            builder.Property(e => e.ModifiedOn).HasDefaultValue(null);

            builder.HasOne(e => e.User)
            .WithMany(u => u.Groups)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.UserId)
            .IsRequired(true);

        }
    }
}