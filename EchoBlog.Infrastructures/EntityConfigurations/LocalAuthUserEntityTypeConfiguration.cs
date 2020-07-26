using EchoBlog.Domains.UserAggregate;
using EchoBlog.Infrastructures.Core;
using EchoBlog.Infrastructures.Core.Snowflake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoBlog.Infrastructures.EntityConfigurations
{
    public class LocalAuthUserEntityTypeConfiguration : BaseEntityTypeConfiguration<LocalAuthUser>
    {
        public LocalAuthUserEntityTypeConfiguration(SnowflakeId snowflakeId) : base(snowflakeId) { }

        public override void Configure(EntityTypeBuilder<LocalAuthUser> builder)
        {
            builder.ToTable("localauthuser");
            /*builder.Property(p => p.UserId).HasColumnName("用户 Id");
            builder.Property(p => p.UserName).HasColumnName("用户登录名");
            builder.Property(p => p.Password).HasColumnName("用户登录口令");*/
            base.Configure(builder);
        }
    }
}
