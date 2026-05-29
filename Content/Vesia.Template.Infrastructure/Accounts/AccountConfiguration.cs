using Vesia.Template.Domain.AccountManagement.AggragateRoot;
using Vesia.Template.Domain.AccountManagement.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vesia.Template.Infrastructure.Accounts;

internal class AccountConfigurations : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {

        builder.ToTable("Accounts", "Test"); //Example

        builder.HasKey(a => a.Id);

        // Configure the AccountId value object
        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Value,                     // To database (Guid)
                value => AccountId.From(value))     // From database (AccountId)
            .HasColumnName("Id");

        builder.Property(a => a.AccountName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(a => a.FirstName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.LastName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.Property(a => a.LastModifiedAt)
            .IsRequired(false);

        builder.Property(a => a.ValidTo)
            .IsRequired(false);

        // Ignore domain events - they're not persisted (Only exists in the Domain layer - Not the Database)
        builder.Ignore(a => a.DomainEvents);

        // Optional: Add indexes
        builder.HasIndex(a => a.AccountName).IsUnique();
        builder.HasIndex(a => a.Email).IsUnique();
    }

}