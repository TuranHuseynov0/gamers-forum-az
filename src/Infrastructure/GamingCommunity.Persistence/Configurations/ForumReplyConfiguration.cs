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
    public class ForumReplyConfiguration : IEntityTypeConfiguration<ForumReply>
    {
        public void Configure(EntityTypeBuilder<ForumReply> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(5000);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
