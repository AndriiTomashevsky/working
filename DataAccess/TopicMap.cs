using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class TopicMap
    {
        public TopicMap(EntityTypeBuilder<Topic> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder
                .HasOne(t => t.UserAsset)
                .WithMany(u => u.Topics)
                .HasForeignKey(t => t.UserAssetId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
