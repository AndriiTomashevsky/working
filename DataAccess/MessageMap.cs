using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MessageMap
    {
        public MessageMap(EntityTypeBuilder<Message> entityBuilder)
        {
            entityBuilder.HasKey(m => m.Id);

            entityBuilder
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.UserAssetId)
                .OnDelete(DeleteBehavior.SetNull);

            entityBuilder
                .HasOne(m => m.Topic)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
