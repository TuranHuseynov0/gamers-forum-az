using GamingCommunity.Domain.Entities.Forums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCommunity.Persistence.Configurations
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(r => r.Content)
                   .IsRequired();

            builder.Property(r => r.VoteScore)
                   .HasDefaultValue(0);

            // Topic -> Reply
            builder.HasOne(r => r.Topic)
                   .WithMany(t => t.Replies)
                   .HasForeignKey(r => r.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.ParentReply)
                   .WithMany(r => r.ChildReplies)
                   .HasForeignKey(r => r.ParentReplyId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.User)
                   .WithMany()
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(r => r.TopicId);
            builder.HasIndex(r => r.ParentReplyId);
        }
    }
}
