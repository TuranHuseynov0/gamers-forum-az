using GamingCommunity.Domain.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Persistence.Configurations
{
    public class TopicVoteConfiguration : IEntityTypeConfiguration<TopicVote>
    {
        public void Configure(EntityTypeBuilder<TopicVote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.VoteType)
                .IsRequired();

            builder.HasIndex(x => new { x.TopicId, x.UserId })
                .IsUnique();

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.TopicVotes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
