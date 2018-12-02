using BudgetScale.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Persistence.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(e => e.AccountId);

            builder.Property(e => e.AccountName).IsRequired().HasMaxLength(20);

            builder.HasOne(e => e.ApplicationUser)
            .WithMany(e => e.Accounts)
            .HasForeignKey(e => e.UserId);
        }
    }
}