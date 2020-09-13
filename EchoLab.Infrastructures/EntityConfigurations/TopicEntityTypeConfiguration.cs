using EchoLab.Domains.TopicAggregate;
using EchoLab.Infrastructures.Core;
using EchoLab.Infrastructures.Core.Snowflake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Infrastructures.EntityConfigurations
{
    /// <summary>
    /// Topic 实体类与数据库映射配置
    /// </summary>
    public class TopicEntityTypeConfiguration : BaseEntityTypeConfiguration<Topic>
    {
        public TopicEntityTypeConfiguration(SnowflakeId snowflakeId) : base(snowflakeId) { }

        public override void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("topic");
            /*builder.Property(p => p.AuthorId).HasMaxLength(20).HasComment("作者 Id");
            builder.Property(p => p.AuthorName).HasMaxLength(20).HasComment("作者名称");
            builder.Property(p => p.Title).HasMaxLength(50).HasComment("标题");*/
            base.Configure(builder);
        }
    }
}
