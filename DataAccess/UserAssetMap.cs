using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserAssetMap
    {
        public UserAssetMap(EntityTypeBuilder<UserAsset> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            //entityBuilder
            //    .HasOne(ua => ua.User)
            //    .WithOne(u => u.UserAsset)
            //    .HasForeignKey(uaa=>uaa.);
        }
    }
}
