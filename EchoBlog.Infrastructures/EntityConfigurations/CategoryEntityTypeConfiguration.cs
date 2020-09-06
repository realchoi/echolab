using EchoBlog.Domains.CategoryAggregate;
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
    /// Category 实体类与数据库映射配置
    /// </summary>
    public class CategoryEntityTypeConfiguration : BaseEntityTypeConfiguration<Category>
    {
        public CategoryEntityTypeConfiguration(SnowflakeId snowflakeId) : base(snowflakeId)
        {
        }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");
            base.Configure(builder);
        }
    }
}
