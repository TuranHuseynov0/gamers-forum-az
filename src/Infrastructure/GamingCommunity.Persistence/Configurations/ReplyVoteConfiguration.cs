using GamingCommunity.Domain.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingCommunity.Persistence.Configurations
{
    public class ReplyVoteConfiguration : IEntityTypeConfiguration<ReplyVote>
    {
        public void Configure(EntityTypeBuilder<ReplyVote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.VoteType)
                .IsRequired();

            builder.HasIndex(x => new { x.Id, x.VoteType })
                .IsUnique();

            builder.HasOne(x => x.Reply)
            .WithMany(x => x.Votes)
            .HasForeignKey(x => x.ReplyId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.ReplyVotes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
