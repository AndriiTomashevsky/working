using DataAccess;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new TopicMap(modelBuilder.Entity<Topic>());
            //new MessageMap(modelBuilder.Entity<Message>());
            //new UserAssetMap(modelBuilder.Entity<UserAsset>());

            modelBuilder.Entity<Topic>().ToTable("Topic");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<UserAsset>().ToTable("UserAsset");
        }
    }
}
