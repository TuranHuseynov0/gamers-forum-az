using GamingCommunity.Domain.Entities;
using GamingCommunity.Domain.Entities.Forums;
using GamingCommunity.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingCommunity.Persistence.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Value)
                   .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Vote_Value",
                "[Value] IN (1, -1)"));

            builder.HasIndex(v => new { v.UserId, v.TargetType, v.TargetId })
                   .IsUnique();

            builder.HasOne<AppUser>()
                   .WithMany()
                   .HasForeignKey(v => v.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
