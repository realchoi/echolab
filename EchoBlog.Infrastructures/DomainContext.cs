using EchoBlog.Domains.ArticleAggregate;
using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.Core.Snowflake;
using EchoBlog.Infrastructures.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures
{
    public class DomainContext : EFContext
    {
        private readonly SnowflakeId _snowflakeId;

        public DomainContext(DbContextOptions options, SnowflakeId snowflakeId) : base(options)
        {
            this._snowflakeId = snowflakeId;
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<LocalAuthUser> LocalAuthUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleEntityTypeConfiguration(this._snowflakeId));
            modelBuilder.ApplyConfiguration(new UserProfileEntityTypeConfiguration(this._snowflakeId));
            modelBuilder.ApplyConfiguration(new LocalAuthUserEntityTypeConfiguration(this._snowflakeId));

            base.OnModelCreating(modelBuilder);
        }
    }
}
