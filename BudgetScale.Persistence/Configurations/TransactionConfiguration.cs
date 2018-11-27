using BudgetScale.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetScale.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(e => e.TransactionId);

            builder.HasOne(e => e.SourceAccount)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.SourceAccountId);

            builder.HasOne(e => e.Category)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.CategoryId);

            builder.Property(e => e.Amount).HasDefaultValue(0.0m);
        }
    }
}