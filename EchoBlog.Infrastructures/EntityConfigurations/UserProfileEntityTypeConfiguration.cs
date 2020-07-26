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
    /// <summary>
    /// Userprofile 实体类与数据库映射配置
    /// </summary>
    public class UserProfileEntityTypeConfiguration : BaseEntityTypeConfiguration<UserProfile>
    {
        public UserProfileEntityTypeConfiguration(SnowflakeId snowflakeId) : base(snowflakeId) { }

        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("userprofile");
            /*builder.Property(p => p.Name).HasColumnName("用户名");
            builder.Property(p => p.Email).HasColumnName("电子邮件地址");
            builder.Property(p => p.Github).HasColumnName("GitHub 地址");
            builder.Property(p => p.Website).HasColumnName("个人网站地址");*/
            base.Configure(builder);
        }
    }
}
