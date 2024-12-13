using ExpenseApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseApp.Data
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Phone).HasMaxLength(15);

            builder.HasMany(p => p.Expenses)
                   .WithOne(e => e.Profile)
                   .HasForeignKey(e => e.ProfileId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
