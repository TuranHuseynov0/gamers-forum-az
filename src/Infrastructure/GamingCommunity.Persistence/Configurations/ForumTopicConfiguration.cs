using GamingCommunity.Domain.Entities.Forum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
    namespace GamingCommunity.Persistence.Configurations
{
    public class ForumTopicConfiguration : IEntityTypeConfiguration<ForumTopic>
    {
        public void Configure(EntityTypeBuilder<ForumTopic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
