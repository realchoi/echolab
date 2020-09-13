using EchoLab.Domain.Abstractions;
using EchoLab.Infrastructures.Core.Snowflake;
using EchoLab.Infrastructures.Core.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EchoLab.Infrastructures.Core
{
    /// <summary>
    /// 实体配置基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity<long>
    {
        private readonly SnowflakeId _snowflakeId;

        public BaseEntityTypeConfiguration(SnowflakeId snowflakeId)
        {
            _snowflakeId = snowflakeId;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasValueGenerator((a, b) => new IdGenerator(_snowflakeId)).ValueGeneratedOnAdd();
            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.CreateTime).HasColumnName("CreateTime");
            builder.Property(t => t.LastTime).HasColumnName("LastTime");
        }
    }
}
